using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BackEndNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountServices accountServices, IConfiguration configuration)
        {
            _accountServices = accountServices;
            _configuration = configuration;
        }

        /*
         Input: {returnMessage, returnCode, user}
         Process:
            1. Call service để lấy thông tin tài khoản
            2. if (resultData.ReturnCode < 0) return result...
            3. Create token
                3.1 Create claims for body of jwt token
                3.2 create token by function createToken
            4. Assign token to returnData to return
         Output: 
         */
        [HttpPost("AccountLogin")]
        public async Task<IActionResult> AccountLogin(AccountRequestData accountRequestData)
        {
            var returnData = new LoginResponseData();
            try
            {
                // Bước 1: Gọi login để lấy thông tin tài khoản
                var result = await _accountServices.AccountLogin(accountRequestData);

                if (result.ReturnCode < 0)
                {
                    return Ok(result);
                }

                // Bước 2: Tạo token 
                var user = result.User;
                // Bước 2.1: Tạo claims để lưu thông tin token
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.PrimarySid, user.UserID.ToString())
                };
                // Bước 2.2: Tạo token
                var newToken = CreateToken(claims);
                // Bước 2.3: Update RefreshToken here
                var refreshToken = GenerateRefreshToken();

                var expiredDays = Convert.ToInt32(_configuration["JWT:RefreshTokenValidityInDays"]);

                var updateData = new AccountUpdateRefreshTokenRequestData();
                updateData.RefreshToken = refreshToken;
                updateData.Expired = DateTime.Now.AddDays(expiredDays);
                updateData.UserID = user.UserID;


                await _accountServices.AccountUpdateRefreshToken(updateData);

                // Bước 3: Trả về token cho client
                returnData.ReturnCode = result.ReturnCode;
                returnData.ReturnMessage = result.ReturnMessage;
                returnData.User = user;
                returnData.Token = new JwtSecurityTokenHandler().WriteToken(newToken);

                return Ok(returnData);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}

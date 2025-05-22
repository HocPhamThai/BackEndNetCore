using DataAccess.NetCore.Data;
using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly ApplicationBEDbContext _context;
        public AccountServices(ApplicationBEDbContext context)
        {
            _context = context;
        }

        /*
         Input: username, password
         Process: call db to authenticate and return data 
            get user based on username, password and return to controller to handle logic
         Output: {returncode, return message, return User)
         */
        public async Task<LoginResponseData> AccountLogin(AccountRequestData requestData)
        {
            var returnData = new LoginResponseData();
            try
            {
                if (string.IsNullOrEmpty(requestData.Username) || string.IsNullOrEmpty(requestData.Password))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Username or Password is empty";
                    return returnData;
                }

                await Task.Yield();

                // xử lý logic gọi db
                var hashPassword = Security.ComputeSha256Hash(requestData.Password);

                var user = _context.User.ToList().FirstOrDefault(x => x.Username.ToLower() == requestData.Username.ToLower() && x.Password == hashPassword);

                if (user == null)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Username or Password is incorrect";
                    return returnData;
                }

                returnData.ReturnCode = 1;
                returnData.ReturnMessage = "Login success";
                returnData.User = user;
                return returnData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AccountUpdateRefreshToken(AccountUpdateRefreshTokenRequestData requestData)
        {
            try
            {
                var user = _context.User.ToList().FirstOrDefault(x => x.UserID == requestData.UserID);
                
                if (user == null || user.UserID < 0)
                {
                    return -1;
                }
                user.RefreshToken = requestData.RefreshToken;
                user.Expired = (DateTime)requestData.Expired;

                _context.User.Update(user);
                _context.SaveChanges();
                return 1;
            } 
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Function> GetFunctionByCode(string code)
        {
            var data = await _context.Function.FirstOrDefaultAsync(x => x.FunctionCode == code);
            return data;
        }

        public async Task<UserPemission> GetUserPemissionByUserID(int userID, int functionID)
        {
            var data = await _context.UserPemission.FirstOrDefaultAsync(x => x.UserID == userID && x.FunctionID == functionID);
            return data;
        }
    }
}

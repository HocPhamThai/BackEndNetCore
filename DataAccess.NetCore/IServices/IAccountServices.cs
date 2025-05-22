using DataAccess.NetCore.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.IServices
{
    public interface IAccountServices
    {
        Task<LoginResponseData> AccountLogin(AccountRequestData requestData);
        Task<int> AccountUpdateRefreshToken(AccountUpdateRefreshTokenRequestData requestData);
        // for check permission
        Task<Function> GetFunctionByCode(string code);
        Task<UserPemission> GetUserPemissionByUserID(int userID, int functionID);
    }
}

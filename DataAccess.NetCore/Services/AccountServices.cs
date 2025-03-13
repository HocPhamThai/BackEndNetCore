using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class AccountServices : IAccountServices
    {
        public async Task<ReturnData> AccountLogin(AccountRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                if (string.IsNullOrEmpty(requestData.Username) || string.IsNullOrEmpty(requestData.Password))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Username or Password is empty";
                    return returnData;
                }

                // xử lý logic gọi db

                returnData.ReturnCode = 1;
                returnData.ReturnMessage = "Login success";
                return returnData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

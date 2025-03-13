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
        Task<ReturnData> AccountLogin(AccountRequestData requestData);
    }
}

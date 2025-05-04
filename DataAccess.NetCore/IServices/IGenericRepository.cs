using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.IServices
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAll();
        Task<int> Insert(T entity);
    }
}

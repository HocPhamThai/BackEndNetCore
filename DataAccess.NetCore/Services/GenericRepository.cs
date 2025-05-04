using DataAccess.NetCore.Data;
using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationBEDbContext _context;
        public GenericRepository(ApplicationBEDbContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<int> Insert(T entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }
    }
}

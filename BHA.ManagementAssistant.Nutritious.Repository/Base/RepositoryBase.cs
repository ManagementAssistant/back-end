using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHA.ManagementAssistant.Nutritious.Repository.Base
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
    {
        protected internal ManagementAssistantContext _context { get; set; }
        private DbSet<T> _dbSet;

        public RepositoryBase(ManagementAssistantContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public bool Create(T Entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T Entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(bool? isDeleted = false)
        {
            return GetQuery(false, true);
        }

        public T GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(T Entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> ForJoin(bool? isDeleted = false)
        {
            throw new NotImplementedException();
        }
    }
}

using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Context;
using BHA.ManagementAssistant.Nutritious.Common.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHA.ManagementAssistant.Nutritious.Common;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Entity;

namespace BHA.ManagementAssistant.Nutritious.Repository.Base
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
    {
        protected internal ManagementAssistantContext _context { get; set; }
        private IRepositoryBase<Organization> _repositoryOrganization;
        private IRepositoryBase<User> _repositoryUser;
        private User _user = new User();
        private IQueryable<User> _queryUser;
        private DbSet<T> _dbSet;

        public RepositoryBase(ManagementAssistantContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _user = _repositoryUser.GetByID(System.Threading.Thread.CurrentPrincipal.Identity.GetUserID());
            _queryUser = _repositoryUser.ForJoin();
        }

        public bool Create(T entity)
        {
            BeforeCreateOperation(ref entity);
            _dbSet.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Delete(T entity)
        {
            BeforeDeleteOperation(ref entity);
            _dbSet.Update(entity);
            _context.SaveChanges();

            return true;
        }

        public IQueryable<T> GetAll(bool? isDeleted = false)
        {
            IQueryable<T> query = _dbSet.AsNoTracking().AsQueryable();
            return GetQuery(query, false, isDeleted.Value);
        }

        public T GetByID(int id)
        {
            T entity = _dbSet.Find(id);

            return entity;
        }

        public async Task<T> GetByIDAsync(int id)
        {
            T entity = await _dbSet.FindAsync(id);

            return entity;
        }

        public bool AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return true;
        }

        public bool Update(T entity)
        {
            BeforeUpdateOperation(ref entity);
            _dbSet.Update(entity);
            _context.SaveChanges();

            return true;
        }

        public IQueryable<T> ForJoin(bool? isDeleted = false)
        {
            IQueryable<T> query = _dbSet.AsNoTracking().AsQueryable();
            return GetQuery(query, true, isDeleted.Value);
        }
    }
}

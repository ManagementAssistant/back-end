using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Context;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHA.ManagementAssistant.Nutritious.Repository.Base
{
    public partial class MARepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceProvider _serviceProvider;
        protected internal ManagementAssistantContext _context { get; set; }
        private User _user = new User();
        private DbSet<T> _dbSet;

        public MARepository(ManagementAssistantContext context, IHttpContextAccessor httpContextAccessor, IServiceProvider serviceProvider)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _httpContextAccessor = httpContextAccessor;
            _serviceProvider = serviceProvider;
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
            IRepository<User> repositoryUser = _serviceProvider.GetService(typeof(IRepository<User>)) as IRepository<User>;
            var x = repositoryUser.Test();
            var Z = x.ToList();
            //IQueryable queryUser = _serviceScope.ServiceProvider.GetService<IRepository<User>>().GetAll();
            IQueryable<T> query = _dbSet.AsNoTracking().AsQueryable();
            return GetQuery(query, true, isDeleted.Value);
        }

        public IQueryable<T> Test()
        {
            return _dbSet.AsQueryable();
        }
    }
}

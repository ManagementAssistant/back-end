using BHA.ManagementAssistant.Nutritious.Common.Extension;
using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Context;
using BHA.ManagementAssistant.Nutritious.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHA.ManagementAssistant.Nutritious.Repository.Base
{
    public partial class MARepository<T> : IRepository<T> where T : class, IEntity
    {
        private IServiceProvider _serviceProvider;
        private IUserRepository _repositoryUser;
        private IOrganizationRepository _repositoryOrganization;
        protected internal ManagementAssistantContext _context { get; set; }
        private DbSet<T> _dbSet;

        public MARepository(ManagementAssistantContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _serviceProvider = serviceProvider;

            IUserRepository repositoryUser = _serviceProvider.GetService<IUserRepository>();
            IOrganizationRepository repositoryOrganization = _serviceProvider.GetService<IOrganizationRepository>();
            _repositoryUser = repositoryUser;
            _repositoryOrganization = repositoryOrganization;
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

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}

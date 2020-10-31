﻿using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHA.ManagementAssistant.Nutritious.Core.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
    {
        protected internal ManagementAssistantContext _context { get; set; }
        private DbSet<T> _dbSet;

        public RepositoryBase(ManagementAssistantContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public int Count()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
    }
}
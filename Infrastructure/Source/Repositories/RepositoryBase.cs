﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Infrastructure.Context;

    public abstract class RepositoryBase<TModel> : IService<TModel> where TModel : class, IModel
    {
        private readonly MyExpensesContext _context;

        protected RepositoryBase(MyExpensesContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TModel> Get(params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> set = _context.Set<TModel>();

            foreach (var include in includes)
                set = set.Include(include);

            return set;
        }

        public virtual TModel GetById(long id, params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> set = _context.Set<TModel>();

            foreach (var include in includes)
                set = set.Include(include);

            return set.SingleOrDefault(x => x.Id == id);
        }

        public async Task<TModel> GetByIdAsync(long id, params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> set = _context.Set<TModel>();

            foreach (var include in includes)
                set = set.Include(include);

            return await set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Remove(long id)
        {
            TModel model = _context.Set<TModel>().Find(id);
            if (model == null)
                return false;

            return _context.Set<TModel>().Remove(model) != null;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            TModel model = await GetByIdAsync(id);
            if (model == null)
                return false;

            return _context.Remove(model) != null;
        }

        public TModel Update(TModel model)
        {
            if (model == null)
                return null;

            TModel existModel = _context.Set<TModel>().Find(model.Id);
            if (existModel == null)
                return null;

            // copy attributes
            existModel.Copy(model);
            return existModel;
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            if (model == null)
                return null;

            TModel existModel = await GetByIdAsync(model.Id);
            if (existModel == null)
                return null;

            // copy attributes
            existModel.Copy(model);
            return existModel;
        }

        public TModel Add(TModel model)
        {
            if (model == null)
                return null;

            var newModel = _context.Set<TModel>().Add(model);
            return newModel?.Entity;
        }

        public async Task<TModel> AddAsync(TModel model)
        {
            if (model == null)
                return null;

            var newModel = await _context.Set<TModel>().AddAsync(model);
            return newModel.Entity;
        }
    }
}

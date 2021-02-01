﻿using BlogApp.DataAccess.Concrete.Context;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, ITable
    {
        public async Task Create(T entity)
        {
            using var context = new BlogAppContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            using var context = new BlogAppContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            using var context = new BlogAppContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> tableFilter)
        {
            using var context = new BlogAppContext();
            return await context.Set<T>().Where(tableFilter).ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> tableFilter)
        {
            using var context = new BlogAppContext();
            return await context.Set<T>().FirstOrDefaultAsync(tableFilter);
        }

        public async Task Update(T entity)
        {
            using var context = new BlogAppContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}

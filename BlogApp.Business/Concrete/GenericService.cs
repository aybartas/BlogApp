using BlogApp.Business.Interfaces;
using BlogApp.DataAccess.Interfaces;
using BlogApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class, ITable
    {
        IGenericDal<T> genericDal;

        public GenericService(IGenericDal<T> genericDal)
        {
            this.genericDal = genericDal;
        }

        public async Task Create(T entity)
        {
            await genericDal.Create(entity);
        }

        public async Task Delete(T entity)
        {
            await genericDal.Delete(entity);
        }

        public async Task<T> FindById(int id)
        {
           return await genericDal.FindById(id);
        }

        public async Task<List<T>> GetAll()
        {
           return await genericDal.GetAll();
        }

        public async Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> tableFilter)
        {
            return  await genericDal.GetAllByFilter(tableFilter);
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> tableFilter)
        {
            return await genericDal.GetByFilter(tableFilter);
        }

        public async Task Update(T entity)
        {
             await genericDal.Update(entity);
        }
    }
}

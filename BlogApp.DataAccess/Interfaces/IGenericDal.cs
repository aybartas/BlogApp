using BlogApp.Entities.Concrete;
using BlogApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Interfaces
{
   public interface IGenericDal<T> where T: ITable
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> tableFilter);
        Task<T> GetByFilter(Expression<Func<T, bool>> tableFilter);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> FindById(int id);

        Task<List<T>> GetAllWithDescendingOrder<TKey>(Expression<Func<T, TKey>> keySelector);

        Task<List<T>> GetAllWithFilterDescending<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector);


    }
}

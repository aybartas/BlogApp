using BlogApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Interfaces
{
    public interface IGenericService<T> where T: class,ITable
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> tableFilter);
        Task<T> GetByFilter(Expression<Func<T, bool>> tableFilter);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }

}

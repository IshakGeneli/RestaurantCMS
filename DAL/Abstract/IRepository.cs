using System.Collections.Generic;

namespace RestaurantCMS.DAL.Abstract
{
    public interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T Get(T entity);
        T Add(T entity);
        List<T> AddRange(List<T> entities);
        T Update(T entity);
        List<T> UpdateRange(List<T> entities);
        T Delete(T entity);
        List<T> DeleteRange(List<T> entities);
    }
}

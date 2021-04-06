using System.Collections.Generic;

namespace RestaurantCMS.DAL.Abstract
{
    public interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        List<T> AddRange(List<T> entities);
        T Update(T entity);
        List<T> UpdateRange(List<T> entities);
        T Delete(int id);
        List<T> DeleteRange(List<T> entities);
    }
}

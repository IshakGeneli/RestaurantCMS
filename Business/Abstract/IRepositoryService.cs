using System.Collections.Generic;

namespace RestaurantCMS.Business.Abstract
{
    public interface IRepositoryService<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(int id);
    }
}

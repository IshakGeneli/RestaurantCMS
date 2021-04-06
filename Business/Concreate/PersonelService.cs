using RestaurantCMS.Business.Abstract;
using RestaurantCMS.DAL.Abstract;
using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.Business.Concreate
{
    public class PersonelService : IPersonelService
    {
        private IPersonelDal _personelDal;
        public PersonelService(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }
        public Personel Add(Personel entity)
        {
            return _personelDal.Add(entity);
        }

        public Personel Delete(int id)
        {
            return _personelDal.Delete(id);
        }

        public List<Personel> GetAll()
        {
            return _personelDal.GetAll();
        }

        public Personel GetById(int id)
        {
            return _personelDal.GetById(id);
        }

        public Personel Update(Personel personel)
        {
            return _personelDal.Update(personel);
        }
    }
}

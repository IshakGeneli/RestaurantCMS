using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.DAL.Abstract
{
    public interface IReservationDal : IRepository<Reservation>
    {
        List<Reservation> GetNotExpired();
    }
}

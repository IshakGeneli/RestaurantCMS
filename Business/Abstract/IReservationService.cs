using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.Business.Abstract
{
    public interface IReservationService : IRepositoryService<Reservation>
    {
        List<Reservation> GetNotExpired();
    }
}

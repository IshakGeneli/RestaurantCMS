using RestaurantCMS.Business.Abstract;
using RestaurantCMS.DAL.Abstract;
using RestaurantCMS.Models;
using System;
using System.Collections.Generic;

namespace RestaurantCMS.Business.Concreate
{
    public class ReservationService : IReservationService
    {
        private IReservationDal _reservationDal;
        public ReservationService(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }
        public Reservation Add(Reservation entity)
        {
           return _reservationDal.Add(entity);
        }

        public Reservation Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAll()
        {
            return _reservationDal.GetAll();
        }

        public Reservation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetNotExpired()
        {
            return _reservationDal.GetNotExpired();
        }

        public Reservation Update(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.Data.Database;
using HotelManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HotelManagement.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public List<HotelViewModel> GetHotels()
        {
            List<Hotel> hotels = new List<Hotel>();
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                hotels = db.Hotels.OrderBy(x => x.Name).ToList();
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hotel, HotelViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            List<HotelViewModel> hotelViewModels = mapper.Map<List<Hotel>, List<HotelViewModel>>(hotels);
            return hotelViewModels;
        }

        public bool InsertHotel(HotelViewModel hotel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HotelViewModel, Hotel>();
            });
            IMapper mapper = config.CreateMapper();
            var Hotel = mapper.Map<HotelViewModel, Hotel>(hotel);
            bool status = false;
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                Hotel.Created_Date = DateTime.Now;
                db.Hotels.Add(Hotel);
                if (db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }
    }
}

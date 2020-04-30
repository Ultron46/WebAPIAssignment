using AutoMapper;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.Data.Database;
using HotelManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public List<HotelViewModel> GetHotels()
        {
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                try
                {
                    List<Hotel> hotels = db.Hotels.OrderBy(x => x.Name).ToList();
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Hotel,HotelViewModel>();
                    });

                    IMapper mapper = config.CreateMapper();
                    List<HotelViewModel> hotelViewModels = new List<HotelViewModel>();
                    foreach(Hotel hotel in hotels)
                    {
                        var Hotel = mapper.Map<Hotel,HotelViewModel>(hotel);
                        hotelViewModels.Add(Hotel);
                    }
                    return hotelViewModels;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new List<HotelViewModel>();
                }
            }
        }

        public bool InsertHotel(HotelViewModel hotel)
        {
            try
            {
                bool status = false;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<HotelViewModel, Hotel>();
                });
                IMapper mapper = config.CreateMapper();
                var Hotel = mapper.Map<HotelViewModel, Hotel>(hotel);
                using (HotelManagementEntities db = new HotelManagementEntities())
                {
                    Hotel.Created_Date = DateTime.Now;
                    db.Hotels.Add(Hotel);
                    if(db.SaveChanges() > 0)
                    {
                        status = true;
                    }
                }
                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

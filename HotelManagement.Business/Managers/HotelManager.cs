using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.Data.Interfaces;
using System.Collections.Generic;

namespace HotelManagement.Business.Managers
{
    public class HotelManager : IHotelManager
    {
        private IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public List<HotelViewModel> GetHotels()
        {
            List<HotelViewModel> hotels = _hotelRepository.GetHotels();
            return hotels;
        }

        public bool InsertHotel(HotelViewModel hotel)
        {
            bool status = _hotelRepository.InsertHotel(hotel);
            return status;
        }
    }
}

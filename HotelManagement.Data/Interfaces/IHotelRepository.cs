using HotelManagement.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Interfaces
{
    public interface IHotelRepository
    {
        List<HotelViewModel> GetHotels();
        bool InsertHotel(HotelViewModel hotel);
    }
}

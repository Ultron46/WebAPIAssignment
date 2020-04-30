using HotelManagement.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public interface IHotelManager
    {
        List<HotelViewModel> GetHotels();
        bool InsertHotel(HotelViewModel hotel);
    }
}

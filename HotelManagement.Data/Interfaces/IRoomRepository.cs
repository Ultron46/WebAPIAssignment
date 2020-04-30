using HotelManagement.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Interfaces
{
    public interface IRoomRepository
    {
        List<RoomViewModel> GetRooms(string hotel, string city, string pincode, Nullable<double> price, string category);
        bool InsertRoom(RoomViewModel room);
    }
}

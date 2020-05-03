using HotelManagement.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public interface IRoomManager
    {
        List<RoomViewModel> GetRooms(int? hotel, string city, string pincode, double? price, string category);
        bool InsertRoom(RoomViewModel room);
    }
}

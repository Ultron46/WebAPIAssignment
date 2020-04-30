using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Interfaces
{
    public interface IBookingManager
    {
        bool GetRoomAvailability(int roomId, DateTime date);
        bool BookRoom(int roomId, DateTime date);
        bool UpdateBookingDate(int roomId, DateTime date);
        bool UpdateBookingStatus(int bookingId, string status);
        bool DeleteBooking(int bookingId);
    }
}

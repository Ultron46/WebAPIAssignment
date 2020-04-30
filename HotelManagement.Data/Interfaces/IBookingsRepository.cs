using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Interfaces
{
    public interface IBookingsRepository
    {
        bool GetRoomAvailability(int roomId, DateTime date);
        bool BookRoom(int roomId, DateTime date);
        bool UpdateBookingDate(int roomId, DateTime date);
        bool UpdateBookingStatus(int bookingId, string status);
        bool DeleteBooking(int bookingId);
    }
}

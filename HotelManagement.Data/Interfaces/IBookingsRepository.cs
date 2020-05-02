using HotelManagement.BusinessEntities.ViewModels;
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
        bool BookRoom(BookingViewModel booking);
        bool UpdateBookingDate(int bookingId, DateTime date);
        bool UpdateBookingStatus(int bookingId, string status);
        bool DeleteBooking(int bookingId);
    }
}

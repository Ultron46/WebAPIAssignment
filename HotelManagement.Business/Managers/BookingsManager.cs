using HotelManagement.Business.Interfaces;
using HotelManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Managers
{
    public class BookingsManager : IBookingManager
    {
        private IBookingsRepository _bookingsRepository;
        public BookingsManager(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }
        public bool BookRoom(int roomId, DateTime date)
        {
            bool status = _bookingsRepository.BookRoom(roomId, date);
            return status;
        }

        public bool DeleteBooking(int bookingId)
        {
            bool status = _bookingsRepository.DeleteBooking(bookingId);
            return status;
        }

        public bool GetRoomAvailability(int roomId, DateTime date)
        {
            bool status = _bookingsRepository.GetRoomAvailability(roomId, date);
            return status;
        }

        public bool UpdateBookingDate(int roomId, DateTime date)
        {
            bool status = _bookingsRepository.UpdateBookingDate(roomId, date);
            return status;
        }

        public bool UpdateBookingStatus(int bookingId, string status)
        {
            bool updated = _bookingsRepository.UpdateBookingStatus(bookingId, status);
            return updated;
        }
    }
}

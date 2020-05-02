using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.Data.Interfaces;
using System;

namespace HotelManagement.Business.Managers
{
    public class BookingsManager : IBookingManager
    {
        private IBookingsRepository _bookingsRepository;
        public BookingsManager(IBookingsRepository bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }
        public bool BookRoom(BookingViewModel booking)
        {
            bool status = _bookingsRepository.BookRoom(booking);
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

        public bool UpdateBookingDate(int bookingId, DateTime date)
        {
            bool status = _bookingsRepository.UpdateBookingDate(bookingId, date);
            return status;
        }

        public bool UpdateBookingStatus(int bookingId, string status)
        {
            bool updated = _bookingsRepository.UpdateBookingStatus(bookingId, status);
            return updated;
        }
    }
}

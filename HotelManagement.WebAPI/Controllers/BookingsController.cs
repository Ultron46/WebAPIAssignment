using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.WebAPI.Authentication;
using System;
using System.Web.Http;

namespace HotelManagement.WebAPI.Controllers
{
    [RoutePrefix("api/Booking")]
    [BasicAuth]
    public class BookingsController : ApiController
    {
        private IBookingManager _bookingManager;
        public BookingsController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }
        [Route("GetAvailibility")]
        [HttpGet]
        public IHttpActionResult GetRoomAvailibility(int roomId, string date)
        {
            DateTime dateTime = Convert.ToDateTime(date);
            bool status = _bookingManager.GetRoomAvailability(roomId, dateTime);
            return Json(status);
        }
        [Route("Book")]
        [HttpPost]
        public IHttpActionResult BookRoom(BookingViewModel booking)
        {
            bool status = _bookingManager.BookRoom(booking);
            if (status == false)
            {
                return Json(new { error = true, message = "Could not book the room, something went wrong" });
            }
            return Json(new { success = true, message = "Room booked for date " + booking.Booking_Date});
        }
        [Route("UpdateBooking")]
        [HttpPut]
        public IHttpActionResult UpdateBookingDate(BookingViewModel booking)
        {
            bool status = _bookingManager.UpdateBookingDate(booking.RoomID, booking.Booking_Date);
            if (status == false)
            {
                return Json(new { error = true, message = "Could not update booking date, something went wrong" });
            }
            return Json(new { success = true, message = "Booking date updated successfully" });
        }
        [Route("UpdateStatus")]
        [HttpPut]
        public IHttpActionResult UpdateBookingStatus(BookingViewModel booking)
        {
            bool updated = _bookingManager.UpdateBookingStatus(booking.ID, booking.Status);
            if (updated == false)
            {
                return Json(new { error = true, message = "Could not update booking status, something went wrong" });
            }
            return Json(new { success = true, message = "Booking status updated successfully" });
        }
        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult DeleteBooking(int id)
        {
            bool status = _bookingManager.DeleteBooking(id);
            if (status == false)
            {
                return Json(new { error = true, message = "Could not delete booking details, something went wrong" });
            }
            return Json(new { success = true, message = "Booking details deleted successfully" });
        }
    }
}

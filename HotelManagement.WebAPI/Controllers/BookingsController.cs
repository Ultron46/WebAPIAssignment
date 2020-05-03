using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.WebAPI.Authentication;
using System;
using System.Net;
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
            try
            {
                bool status = _bookingManager.GetRoomAvailability(roomId, dateTime);
                return Json(status);
            }
            catch(Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        [Route("Book")]
        [HttpPost]
        public IHttpActionResult BookRoom(BookingViewModel booking)
        {
            try
            {
                bool status = _bookingManager.BookRoom(booking);
                return Json(new { message = "Room booked for date " + booking.Booking_Date});
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        [Route("UpdateBooking")]
        [HttpPut]
        public IHttpActionResult UpdateBookingDate(BookingViewModel booking)
        {
            try
            {
                bool status = _bookingManager.UpdateBookingDate(booking.ID, booking.Booking_Date);
                return Json(new { message = "Booking date updated successfully" });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        [Route("UpdateStatus")]
        [HttpPut]
        public IHttpActionResult UpdateBookingStatus(BookingViewModel booking)
        {
            try
            {
                bool updated = _bookingManager.UpdateBookingStatus(booking.ID, booking.Status);
                return Json(new { message = "Booking status updated successfully" });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteBooking(int id)
        {
            try
            {
                bool status = _bookingManager.DeleteBooking(id);
                return Json(new { message = "Booking details deleted successfully" });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }
    }
}

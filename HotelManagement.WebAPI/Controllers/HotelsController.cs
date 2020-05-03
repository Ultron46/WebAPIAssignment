using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.WebAPI.Authentication;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace HotelManagement.WebAPI.Controllers
{
    [RoutePrefix("api/Hotel")]
    [BasicAuth]
    public class HotelsController : ApiController
    {
        private IHotelManager _hotelManager;
        public HotelsController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }
        [Route("Hotels")]
        [HttpGet]
        public IHttpActionResult GetHotels()
        {
            try
            {
                List<HotelViewModel> hotels = _hotelManager.GetHotels();
                if (hotels.Count == 0 || hotels == null)
                {
                    return Json("No records found");
                }
                return Json(hotels);
            }
            catch(Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }
        [Route("AddHotel")]
        [HttpPost]
        public IHttpActionResult InsertHotel(HotelViewModel hotel)
        {
            try
            {
                bool status = _hotelManager.InsertHotel(hotel);
                return Content(HttpStatusCode.Created, new { message = "Hotel details inserted successfully" });
            }
            catch(Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }
    }
}

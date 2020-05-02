using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.WebAPI.Authentication;
using System.Collections.Generic;
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
            List<HotelViewModel> hotels = _hotelManager.GetHotels();
            if(hotels == null)
            {
                return Json(new { error = true, message = "No Hotel Records Found or Something Went Wrong"});
            }
            return Json(new { success = true, hotels});
        }
        [Route("AddHotel")]
        [HttpPost]
        public IHttpActionResult InsertHotel(HotelViewModel hotel)
        {
            bool status = _hotelManager.InsertHotel(hotel);
            if(status == false)
            {
                return Json(new { error = true, message = "Could not insert hotel details" });
            }
            return Json(new { success = true, message = "Hotel details inserted successfully"});
        }
    }
}

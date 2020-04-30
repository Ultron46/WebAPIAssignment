using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.WebAPI.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.WebAPI.Controllers
{
    public class HotelsController : ApiController
    {
        private IHotelManager _hotelManager;
        public HotelsController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        [BasicAuth, HttpGet]
        public IHttpActionResult GetHotels()
        {
            List<HotelViewModel> hotels = _hotelManager.GetHotels();
            if(hotels == null)
            {
                return NotFound();
            }
            return Ok(hotels);
        }

        [HttpPost]
        public IHttpActionResult InsertHotel(HotelViewModel hotel)
        {
            bool status = _hotelManager.InsertHotel(hotel);
            if(status == false)
            {
                return NotFound();
            }
            return Ok(status);
        }
    }
}

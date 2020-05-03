using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.WebAPI.Authentication;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace HotelManagement.WebAPI.Controllers
{
    [RoutePrefix("api/Room")]
    [BasicAuth]
    public class RoomsController : ApiController
    {
        private IRoomManager _roomManager;
        public RoomsController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }
        [Route("Rooms")]
        [HttpGet]
        public IHttpActionResult GetRooms(string city = null, string pincode = null, string category = null, double? hotelId = null, double? price = null)
        {
            int? hid;
            if(hotelId == null)
            {
                hid = null;
            }
            else
            {
                hid = Convert.ToInt32(hotelId);
            }
            try
            {
                List<RoomViewModel> rooms = _roomManager.GetRooms(hid, city, pincode, price, category);
                if (rooms.Count == 0 || rooms == null)
                {
                    return Json("No Records Found");
                }
                return Json(rooms);
            }
            catch(Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }
        [Route("AddRoom")]
        [HttpPost]
        public IHttpActionResult InsertRoom(RoomViewModel room)
        {
            try
            {
                bool status = _roomManager.InsertRoom(room);
                return Content(HttpStatusCode.Created, new { message = "Room details inserted successfully" });
            }
            catch(Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }
    }
}

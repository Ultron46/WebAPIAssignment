using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.WebAPI.Authentication;
using System.Collections.Generic;
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
        public IHttpActionResult GetRooms(string hotel, string city, string pincode, double? price, string category)
        {
            List<RoomViewModel> rooms = _roomManager.GetRooms(hotel, city, pincode, price, category);
            if(rooms == null)
            {
                return Json(new { error = true, message = "No Records Found or Something Went Wrong" });
            }
            return Json(new { success = true, rooms});
        }
        [Route("AddRoom")]
        [HttpPost]
        public IHttpActionResult InsertRoom(RoomViewModel room)
        {
            bool status = _roomManager.InsertRoom(room);
            if (status == false)
            {
                return Json(new { error = true, message = "Could not insert room details" });
            }
            return Json(new { success = true, message = "Room details inserted successfully" });
        }
    }
}

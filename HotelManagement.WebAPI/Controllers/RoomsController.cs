using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.WebAPI.Controllers
{
    public class RoomsController : ApiController
    {
        private IRoomManager _roomManager;
        public RoomsController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [HttpGet]
        public IHttpActionResult GetRooms(string hotel, string city, string pincode, Nullable<double> price, string category)
        {
            List<RoomViewModel> rooms = _roomManager.GetRooms(hotel, city, pincode, price, category);
            if(rooms == null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        [HttpPost]
        public IHttpActionResult InsertRoom(RoomViewModel room)
        {
            bool status = _roomManager.InsertRoom(room);
            if(status == false)
            {
                return NotFound();
            }
            return Ok(status);
        }
    }
}

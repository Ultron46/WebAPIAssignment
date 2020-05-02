using HotelManagement.Business.Interfaces;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace HotelManagement.Business.Managers
{
    public class RoomManager : IRoomManager
    {
        private IRoomRepository _roomRepository;
        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public List<RoomViewModel> GetRooms(string hotel, string city, string pincode, Nullable<double> price, string category)
        {
            List<RoomViewModel> rooms = _roomRepository.GetRooms(hotel, city, pincode, price, category);
            return rooms;
        }

        public bool InsertRoom(RoomViewModel room)
        {
            bool status = _roomRepository.InsertRoom(room);
            return status;
        }
    }
}

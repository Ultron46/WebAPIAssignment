using AutoMapper;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.Data.Database;
using HotelManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HotelManagement.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public List<RoomViewModel> GetRooms(int? hotelId, string city, string pincode, double? price, string category)
        {
            List<Room> rooms = new List<Room>();
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                var query = from r in db.Rooms select r;
                if(hotelId != null)
                {
                    query = query.Where(x => x.HotelID == hotelId);
                }
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(x => x.Hotel.City == city);
                }
                if (!string.IsNullOrEmpty(pincode))
                {
                    query = query.Where(x => x.Hotel.Pin_Code == pincode);
                }
                if (!string.IsNullOrEmpty(category))
                {
                    query = query.Where(x => x.Category1.Name == category);
                }
                if (price != null)
                {
                    query = query.Where(x => x.Price == price);
                }
                query = query.Include(x => x.Hotel).Include(x => x.Category1).OrderBy(x => x.Price);
                rooms = query.ToList();
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Room, RoomViewModel>().ForMember(d => d.Hotel, o => o.MapFrom(s => s.Hotel)).ForMember(d => d.Category1, o => o.MapFrom(s => s.Category1));
                cfg.CreateMap<Hotel, HotelViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            List<RoomViewModel> roomViewModels = mapper.Map<List<Room>, List<RoomViewModel>>(rooms);
            return roomViewModels;
        }

        public bool InsertRoom(RoomViewModel room)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomViewModel, Room>();
            });
            IMapper mapper = config.CreateMapper();
            var Room = mapper.Map<RoomViewModel, Room>(room);
            bool status = false;
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                Room.Created_Date = DateTime.Now;
                db.Rooms.Add(Room);
                if (db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }
    }
}

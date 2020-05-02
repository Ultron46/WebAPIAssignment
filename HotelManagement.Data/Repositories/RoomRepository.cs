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
        public List<RoomViewModel> GetRooms(string hotel, string city, string pincode, Nullable<double> price, string category)
        {
            List<Room> rooms = new List<Room>();
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                try
                {
                    var query = (from r in db.Rooms where (hotel == null || r.Hotel.Name == hotel) && (city == null || r.Hotel.City == city) && (pincode == null || r.Hotel.Pin_Code == pincode) && (price == null || r.Price == price) && (category == null || r.Category1.Name == category) select r).OrderBy(x => x.Price).Include(x => x.Category1).Include(x => x.Hotel);
                    rooms = query.ToList();
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Room, RoomViewModel>().ForMember(d => d.Hotel, o => o.MapFrom(s => s.Hotel)).ForMember(d => d.Category1, o => o.MapFrom(s => s.Category1));
                        cfg.CreateMap<Hotel, HotelViewModel>();
                        cfg.CreateMap<Category, CategoryViewModel>();
                    });

                    IMapper mapper = config.CreateMapper();
                    List<RoomViewModel> roomViewModels = new List<RoomViewModel>();
                    foreach (Room room in rooms)
                    {
                        var Room = mapper.Map<Room, RoomViewModel>(room);
                        roomViewModels.Add(Room);
                    }
                    return roomViewModels;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new List<RoomViewModel>();
                }
            }
        }

        public bool InsertRoom(RoomViewModel room)
        {
            try
            {
                bool status = false;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RoomViewModel, Room>();
                });
                IMapper mapper = config.CreateMapper();
                var Room = mapper.Map<RoomViewModel, Room>(room);
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

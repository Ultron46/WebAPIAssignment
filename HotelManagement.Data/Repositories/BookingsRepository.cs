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
    public class BookingsRepository : IBookingsRepository
    {
        public bool BookRoom(BookingViewModel booking)
        {
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                bool status = false;
                try
                {
                    Booking temp = db.Bookings.Where(x => x.RoomID == booking.RoomID && x.Booking_Date == booking.Booking_Date).FirstOrDefault();
                    if(temp != null)
                    {
                        return status;
                    }
                    if (string.IsNullOrEmpty(booking.Status))
                    {
                        booking.Status = "Optional";
                    }
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<BookingViewModel, Booking>();
                    });
                    IMapper mapper = config.CreateMapper();
                    var Book = mapper.Map<BookingViewModel, Booking>(booking);
                    db.Bookings.Add(Book);
                    if(db.SaveChanges() > 0)
                    {
                        status = true;
                    }
                    return status;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public bool DeleteBooking(int bookingId)
        {
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                bool status = false;
                try
                {
                    Booking booking = db.Bookings.Where(x => x.ID == bookingId).AsNoTracking().FirstOrDefault();
                    booking.Status = "Deleted";
                    db.Entry(booking).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        status = true;
                    }
                    return status;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public bool GetRoomAvailability(int roomId, DateTime date)
        {
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                bool status = false;
                try
                {
                    List<Booking> bookings = db.Bookings.Where(x => x.RoomID == roomId && x.Booking_Date.Equals(date) && (x.Status == "Optional" || x.Status == "Definitive")).ToList();
                    if (bookings.Count <= 0)
                    {
                        status = true;
                    }
                    return status;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public bool UpdateBookingDate(int bookingId, DateTime date)
        {
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                bool status = false;
                try
                {
                    Booking temp = db.Bookings.Where(x => x.RoomID == bookingId && x.Booking_Date == date).FirstOrDefault();
                    if(temp != null)
                    {
                        return status;
                    }
                    Booking booking = db.Bookings.Where(x => x.RoomID == bookingId).FirstOrDefault();
                    booking.Booking_Date = date; ;
                    if(db.SaveChanges() > 0)
                    {
                        status = true;
                    }
                    return status;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public bool UpdateBookingStatus(int bookingId, string status)
        {
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                bool updated = false;
                try
                {
                    Booking booking = db.Bookings.AsNoTracking().Where(x => x.ID == bookingId).FirstOrDefault();
                    booking.Status = status;
                    db.Entry(booking).State = EntityState.Modified;
                    if(db.SaveChanges() > 0)
                    {
                        updated = true;
                    }
                    return updated;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }
    }
}

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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookingViewModel, Booking>();
            });
            IMapper mapper = config.CreateMapper();
            var Book = mapper.Map<BookingViewModel, Booking>(booking);
            Book.Status = "Optional";
            bool status = false;
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                db.Bookings.Add(Book);
                if (db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool DeleteBooking(int bookingId)
        {
            bool status = false;
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                Booking booking = db.Bookings.Where(x => x.ID == bookingId).AsNoTracking().FirstOrDefault();
                booking.Status = "Deleted";
                db.Entry(booking).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool GetRoomAvailability(int roomId, DateTime date)
        {
            bool status = false;
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                List<Booking> bookings = db.Bookings.Where(x => x.RoomID == roomId && x.Booking_Date.Equals(date) && (x.Status == "Optional" || x.Status == "Definitive")).ToList();
                if (bookings.Count == 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool UpdateBookingDate(int bookingId, DateTime date)
        {
            bool status = false;
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                Booking booking = db.Bookings.Where(x => x.ID == bookingId).FirstOrDefault();
                booking.Booking_Date = date;
                if (db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool UpdateBookingStatus(int bookingId, string status)
        {
            bool updated = false;
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                Booking booking = db.Bookings.Where(x => x.ID == bookingId).FirstOrDefault();
                booking.Status = status;
                db.Entry(booking).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    updated = true;
                }
            }
            return updated;
        }
    }
}

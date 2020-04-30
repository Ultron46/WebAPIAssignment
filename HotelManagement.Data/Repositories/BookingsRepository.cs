using HotelManagement.Data.Database;
using HotelManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Repositories
{
    public class BookingsRepository : IBookingsRepository
    {
        public bool BookRoom(int roomId, DateTime date)
        {
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                bool status = false;
                try
                {
                    Booking temp = db.Bookings.Where(x => x.RoomID == roomId && x.Booking_Date == date).FirstOrDefault();
                    if(temp != null)
                    {
                        return status;
                    }
                    Booking booking = new Booking { RoomID = roomId, Booking_Date = date, Status = "optional" };
                    db.Bookings.Add(booking);
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

        public bool UpdateBookingDate(int roomId, DateTime date)
        {
            using (HotelManagementEntities db = new HotelManagementEntities())
            {
                bool status = false;
                try
                {
                    Booking temp = db.Bookings.Where(x => x.RoomID == roomId && x.Booking_Date == date).FirstOrDefault();
                    if(temp != null)
                    {
                        return status;
                    }
                    Booking booking = db.Bookings.Where(x => x.RoomID == roomId).FirstOrDefault();
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

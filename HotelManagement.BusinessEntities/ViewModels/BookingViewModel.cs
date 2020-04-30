using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessEntities.ViewModels
{
    public class BookingViewModel
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public System.DateTime Booking_Date { get; set; }
        public string Status { get; set; }
    }
}

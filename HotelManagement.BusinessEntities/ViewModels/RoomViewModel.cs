using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessEntities.ViewModels
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Updated_Date { get; set; }
        public string Updated_By { get; set; }
        public HotelViewModel Hotel { get; set; }
        public virtual CategoryViewModel Category1 { get; set; }

    }
}

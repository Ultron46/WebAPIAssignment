using HotelManagement.Data.Interfaces;
using HotelManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace HotelManagement.Business.UnityResolver
{
    public class UnityResolver : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IHotelRepository, HotelRepository>();
            Container.RegisterType<IRoomRepository, RoomRepository>();
            Container.RegisterType<IBookingsRepository, BookingsRepository>();
        }
    }
}

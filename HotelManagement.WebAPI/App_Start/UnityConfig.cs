using HotelManagement.Business.Interfaces;
using HotelManagement.Business.Managers;
using HotelManagement.Business.UnityResolver;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace HotelManagement.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<UnityResolver>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IHotelManager, HotelManager>();
            container.RegisterType<IRoomManager, RoomManager>();
            container.RegisterType<IBookingManager, BookingsManager>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
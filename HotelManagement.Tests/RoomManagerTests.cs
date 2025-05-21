using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelManagement.Business.Managers;
using HotelManagement.BusinessEntities.ViewModels;
using HotelManagement.Data.Interfaces;
using System.Collections.Generic; // For List<RoomViewModel>

namespace HotelManagement.Tests
{
    // Stub implementation for IRoomRepository
    public class StubRoomRepository : IRoomRepository
    {
        private bool _insertRoomResult;

        public void ConfigureInsertRoom(bool result)
        {
            _insertRoomResult = result;
        }

        public bool InsertRoom(RoomViewModel room)
        {
            return _insertRoomResult;
        }

        public List<RoomViewModel> GetRooms(int? hotelId, string city, string pincode, double? price, string category)
        {
            // Not used in these specific tests, can return empty list or null
            return new List<RoomViewModel>();
        }

        // Add other IRoomRepository methods if they are called by the RoomManager constructor or other tested methods.
        // For now, assuming only InsertRoom and GetRooms are relevant.
    }

    [TestClass]
    public class RoomManagerTests
    {
        [TestMethod]
        public void InsertRoom_ShouldReturnTrue_WhenRepositorySucceeds()
        {
            // Arrange
            var stubRepository = new StubRoomRepository();
            stubRepository.ConfigureInsertRoom(true); // Configure repository to simulate success

            var roomManager = new RoomManager(stubRepository);
            var roomViewModel = new RoomViewModel(); // Create a dummy RoomViewModel

            // Act
            bool result = roomManager.InsertRoom(roomViewModel);

            // Assert
            Assert.IsTrue(result, "InsertRoom should return true when repository succeeds.");
        }

        [TestMethod]
        public void InsertRoom_ShouldReturnFalse_WhenRepositoryFails()
        {
            // Arrange
            var stubRepository = new StubRoomRepository();
            stubRepository.ConfigureInsertRoom(false); // Configure repository to simulate failure

            var roomManager = new RoomManager(stubRepository);
            var roomViewModel = new RoomViewModel(); // Create a dummy RoomViewModel

            // Act
            bool result = roomManager.InsertRoom(roomViewModel);

            // Assert
            Assert.IsFalse(result, "InsertRoom should return false when repository fails.");
        }
    }
}

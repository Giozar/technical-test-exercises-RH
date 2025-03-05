using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RoomService.WebAPI.Controllers;
using RoomService.WebAPI.Models;
using Xunit;

namespace RoomService.Tests
{
    public class RoomsControllerTests
    {
        [Fact]
        public void CreateRoom_ValidRoom_ReturnsCreatedResult()
        {
            // Arrange
            var controller = new RoomsController();
            
            // Generamos un ID único basado en la marca de tiempo actual para evitar conflictos
            var uniqueId = (int)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() % 10000);
            
            var room = new Room
            {
                Id = uniqueId,
                Category = "Luxe",
                Number = 122,
                Floor = 3,
                IsAvailable = true,
                AddedDate = 1573843210
            };

            // Act
            var result = controller.CreateRoom(room);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<Room>(createdAtActionResult.Value);
            Assert.Equal(room.Id, returnValue.Id);
        }

        [Fact]
        public void GetRoomById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var controller = new RoomsController();
            // Limpiar habitaciones existentes para evitar conflictos
            controller.ClearRooms();
            
            var room = new Room
            {
                Id = 1,
                Category = "Luxe",
                Number = 122,
                Floor = 3,
                IsAvailable = true,
                AddedDate = 1573843210
            };
            controller.CreateRoom(room);

            // Act
            var result = controller.GetRoomById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Room>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public void GetRoomById_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var controller = new RoomsController();
            // Limpiar habitaciones existentes para evitar conflictos
            controller.ClearRooms();

            // Act
            var result = controller.GetRoomById(999);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetAllRooms_WithFloorFilter_ReturnsFilteredRooms()
        {
            // Arrange
            var controller = new RoomsController();
            // Limpiar habitaciones existentes para evitar conflictos
            controller.ClearRooms();
            controller.CreateRoom(new Room { Id = 1, Category = "Luxe", Number = 101, Floor = 1, IsAvailable = true });
            controller.CreateRoom(new Room { Id = 2, Category = "Standard", Number = 201, Floor = 2, IsAvailable = true });
            controller.CreateRoom(new Room { Id = 3, Category = "Luxe", Number = 301, Floor = 3, IsAvailable = true });

            // Act
            var result = controller.GetAllRooms(new List<int> { 1, 3 });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Room>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
            Assert.Contains(returnValue, r => r.Floor == 1);
            Assert.Contains(returnValue, r => r.Floor == 3);
            Assert.DoesNotContain(returnValue, r => r.Floor == 2);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using AutoGalaxy.Controllers;
using AutoGalaxy.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AutoGalaxy.Tests
{
    public class VehicleControllerTests
    {
        [Fact]
        public void ShouldReturnListOfVehicles()
        {
            var mockRepository = new Mock<IVehicleRepository>();
            var vehicles = VehicleListFactory();
            mockRepository.Setup(repo => repo.GetAll()).Returns(vehicles);
            var controller = new VehiclesController(mockRepository.Object);

            var response = controller.All().Result as ObjectResult;
            
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.Equal(vehicles, response.Value);
        }
        
        [Fact]
        public void ShouldReturnVehicleById()
        {
            var mockRepository = new Mock<IVehicleRepository>();
            var vehicle = VehicleFactory();
            mockRepository.Setup(repo => repo.GetById(1)).Returns(vehicle);
            var controller = new VehiclesController(mockRepository.Object);

            var response = controller.Get(1).Result as ObjectResult;
            
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.Equal(vehicle, response.Value);
        }

        [Fact]
        public void ShouldReturnNotFound_WhenVehicleDoesNotExist()
        {
            var mockRepository = new Mock<IVehicleRepository>();
            var controller = new VehiclesController(mockRepository.Object);

            var response = controller.Get(1);
            var actionResult = Assert.IsType<ActionResult<Vehicle>>(response);

            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        public List<Vehicle> VehicleListFactory()
        {
            var vehicles = new List<Vehicle>();
            vehicles.Add(new Vehicle() { Manufacturer = "Tesla"});
            vehicles.Add(new Vehicle() { Manufacturer = "Nissan"});
            return vehicles;
        }

        public Vehicle VehicleFactory()
        {
            var vehicle = new Vehicle
            {
                Id = 1,
                Manufacturer = "Tesla"
            };
            return vehicle;
        }
    }
}
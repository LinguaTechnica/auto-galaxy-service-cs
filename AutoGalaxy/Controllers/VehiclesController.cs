using System;
using System.Collections.Generic;
using System.Linq;
using AutoGalaxy.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoGalaxy.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository repository;

        public VehiclesController(IVehicleRepository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public ActionResult<List<Vehicle>> All()
        {
            // var v = new Vehicle
            // {
            //     Manufacturer = "Tesla"
            // };
            // Console.Write(repository);
            // repository.Create(v);
            return Ok(repository.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Vehicle> Get(int id)
        {
            var vehicle = repository.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            // if (vehicle.Equals(null)) return NotFound();
            return Ok(vehicle);
        }
    }
}
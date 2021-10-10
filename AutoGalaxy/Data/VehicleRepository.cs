using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AutoGalaxy.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        private AutoGalaxyDBContext context;
        
        public VehicleRepository(AutoGalaxyDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return context.Vehicles.ToList();
        }

        public Vehicle GetById(int vehicleId)
        {
            return context.Vehicles.SingleOrDefault(vehicle => vehicle.Id.Equals(vehicleId));
        }

        public void Create(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
            Save();
        }

        public void Update(Vehicle vehicle)
        {
            context.Vehicles.Update(vehicle);
            Save();
        }

        public void Remove(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
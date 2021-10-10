using System;
using System.Collections;
using System.Collections.Generic;

namespace AutoGalaxy.Data
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetAll();
        Vehicle GetById(int vehicleId);
        void Create(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Remove(Vehicle vehicle);
        void Save();
    }
}
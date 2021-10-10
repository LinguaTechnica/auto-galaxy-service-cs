using Microsoft.EntityFrameworkCore;

namespace AutoGalaxy.Data
{
    public class Vehicle
    {
        public int Id { get; init; }
        public string Manufacturer { get; set; }
    }
}
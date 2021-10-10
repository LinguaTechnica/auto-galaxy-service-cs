using Microsoft.EntityFrameworkCore;

namespace AutoGalaxy.Data
{
    public class AutoGalaxyDBContext : DbContext
    {
        private const string DbConnectionString = "Server=localhost:3306;Database=agtest;Uid=dev;Pwd=admin;";

        public DbSet<Vehicle> Vehicles { get; set; }
        public AutoGalaxyDBContext(DbContextOptions<AutoGalaxyDBContext> options) : base(options)
        {
        }
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySQL(DbConnectionString);
        // }
    }
}
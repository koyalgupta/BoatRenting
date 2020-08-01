using BoatRentSolution.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BoatRentSolution.Repository
{
    public partial class BoatRentContext : DbContext
    {
        public BoatRentContext()
        {
        }

        public BoatRentContext(DbContextOptions<BoatRentContext> options) : base(options)
        {
        }

        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// OnConfiguring Method
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<BoatDetails>(entity =>
            {

            });
        }

        public virtual DbSet<BoatDetails> BoatDetails { get; set; }       
    }
}

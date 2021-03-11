using System.Threading;
using System.Reflection.Emit;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Models;
using Microsoft.Extensions.Options;
using RegistrationAPI.Configuration;
using System.Threading.Tasks;

namespace RegistrationAPI.data
{
  public interface IRegistrationContext
  {
    DbSet<VaccinType> VaccinTypes { get; set; }
    DbSet<VaccinationRegistration> VaccinationRegistrations { get; set; }
    DbSet<VaccinationLocation> VaccinationLocations { get; set; }
    Task<int> SaveChangesAsync(CancellationToken token = default);
  }




  public class RegistrationContext : DbContext, IRegistrationContext
  {

    public DbSet<VaccinType> VaccinTypes { get; set; }
    public DbSet<VaccinationRegistration> VaccinationRegistrations { get; set; }
    public DbSet<VaccinationLocation> VaccinationLocations { get; set; }

    private ConnectionStrings _conntectionStrings;

    public RegistrationContext(DbContextOptions<RegistrationContext> FileOptions, IOptions<ConnectionStrings> connectionstrings)
    {

      _conntectionStrings = connectionstrings.Value;


    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlServer(_conntectionStrings.SQL);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<VaccinType>().HasData(new VaccinType() { VaccinTypeId = Guid.NewGuid(), Name = "Pfizer" });
      modelBuilder.Entity<VaccinationLocation>().HasData(new VaccinationLocation() { VaccinationLocationId = Guid.NewGuid(), Name = "The Penta" });

    }

  }
}

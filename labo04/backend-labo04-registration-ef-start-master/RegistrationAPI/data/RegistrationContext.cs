using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Models;
using Microsoft.Extensions.Options;
using RegistrationAPI.Configuration;

namespace RegistrationAPI.data
{
    public class RegistrationContext : DbContext
    {
        
        public DbSet<VaccinType> VaccinTypes { get; set; }
        public DbSet<VaccinationRegistration> VaccinationRegistrations { get; set; }
        public DbSet<VaccinationLocation> VaccinationLocations { get; set; }

        private ConnectionStrings _conntectionStrings;

        public RegistrationContext(DbContextOptions<RegistrationContext> FileOptions, IOptions<ConnectionStrings> connectionstrings){

            _conntectionStrings = connectionstrings.Value;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlServer();
        }
    }
}

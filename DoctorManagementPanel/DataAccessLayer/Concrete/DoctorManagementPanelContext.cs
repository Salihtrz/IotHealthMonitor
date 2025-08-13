using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class DoctorManagementPanelContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SALIH\\SQLEXPRESS;initial Catalog=DoctorManagementPanelDb;integrated Security=true;TrustServerCertificate=true");
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Pulse> Pulses { get; set; }
        public DbSet<SpO2> SpO2s { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<PatientsRelative> PatientsRelatives { get; set; }
    }

}

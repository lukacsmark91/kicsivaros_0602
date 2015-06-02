using kicsivaros_0602.Models.DataAccess.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace kicsivaros_0602.Models.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> 
    {
        public ApplicationDbContext()
            : base("DefaultConnection")     // connectionStrings
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Orszag> Orszagok { get; set; }
        public DbSet<Epulet> Epuletek { get; set; }
        public DbSet<Egyseg> Egysegek { get; set; }
        public DbSet<OrszagTulajdonsag> OrszagTulajdonsag { get; set; }
        public DbSet<OrszagFejlesztes> OrszagFejlesztes { get; set; }
        public DbSet<OrszagEgyseg> OrszagEgyseg { get; set; }
        public DbSet<OrszagEpulet> OrszagEpulet { get; set; }
        public DbSet<Harc> Harc { get; set; }
        public DbSet<Kor> Kor { get; set; }
    }
}
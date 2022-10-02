using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompanyProject.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DBConnection")
        {

        }
        public DbSet<Karyawan> Karyawan { get; set; }

        public DbSet<KendaraanPerusahaan> KendaraanPerusahaan { get; set; }
    }
}
using EFLoadingRelatedData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLoadingRelatedData.DatabaseContext
{
    class UniversityDbContext:DbContext
    {
        public UniversityDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}

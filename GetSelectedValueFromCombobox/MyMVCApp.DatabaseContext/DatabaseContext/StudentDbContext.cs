using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVCApp.Models.Models;

namespace MyMVCApp.DatabaseContext.DatabaseContext
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Student> Students { set; get; }
        public DbSet<District> Districts { set; get; }
    }
}

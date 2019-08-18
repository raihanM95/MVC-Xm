using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyMVCApp.Models.Models;
using MyMVCApp.DatabaseContext.DatabaseContext;

namespace MyMVCApp.Repository.Repository
{
    public class DistrictRepository
    {
        District _district = new District();
        StudentDbContext db = new StudentDbContext();

        public bool Add(District district)
        {
            db.Districts.Add(district);
            int rowAffected = db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }

            return false;
        }

        public bool Delete(District district)
        {
            //Student std = db.Students.Where(c => c.ID == 1).FirstOrDefault();
            District dist = db.Districts.FirstOrDefault(c => c.ID == district.ID);
            db.Districts.Remove(dist);
            int rowAffected = db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
        public bool Update(District district)
        {
            //Method 1
            //Student std = db.Students.Where(c => c.ID == student.ID).FirstOrDefault();
            //Student std = db.Students.FirstOrDefault(c => c.ID == student.ID);
            //if (student != null)
            //{
            //    student.Name = student.Name;
            //}

            //Method 2
            db.Entry(district).State = EntityState.Modified;

            int rowAffected = db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public List<District> GetAll()
        {

            return db.Districts.ToList();
        }
        public District GetByID(District district)
        {

            //Student std = db.Students.Where(c => c.ID == student.ID).FirstOrDefault();
            District dst = db.Districts.FirstOrDefault(c => c.ID == district.ID);
            return dst;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVCApp.DatabaseContext.DatabaseContext;
using MyMVCApp.Models.Models;

namespace MyMVCApp.Repository.Repository
{
    public class StudentRepository
    {
        StudentDbContext db = new StudentDbContext();
        public bool Add(Student student)
        {
            int isExecuted = 0;

            db.Students.Add(student);
            isExecuted=db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }
        public bool Delete(Student student)
        {
            int isExecuted = 0;
            Student aStudent = db.Students.FirstOrDefault(c=>c.ID == student.ID);

            db.Students.Remove(aStudent);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }


            return false;
        }
        public bool Update(Student student)
        {
            int isExecuted = 0;
            //Method 1
            //Student aStudent = db.Students.FirstOrDefault(c => c.ID == student.ID);
            //if (aStudent != null)
            //{
            //    aStudent.Name = student.Name;
            //    isExecuted = db.SaveChanges();
            //}

            //Method 2
            db.Entry(student).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public List<Student> GetAll()
        {
            return db.Students.Include(c => c.District).ToList();
        }
        public Student GetByID(int studentId)
        {
            Student aStudent = db.Students.FirstOrDefault(c => c.ID == studentId);
            return aStudent;
        }

        public List<Student> GetByDistrict(int districtId)
        {
            return db.Students.Where(c => c.DistrictID == districtId).ToList();
        }
    }
}

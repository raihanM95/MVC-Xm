using EFLoadingRelatedData.DatabaseContext;
using EFLoadingRelatedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EFLoadingRelatedData
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityDbContext db = new UniversityDbContext();

            var departments = db.Departments.ToList();

            foreach(var department in departments)
            {
                Console.WriteLine("Name: " + department.Name + " Code: " + department.Code);


                db.Entry(department)
                    .Collection(c=>c.Students)
                    .Query()
                    .Where(c=>c.IsActive)
                    .Load();
                

                if(department.Students!=null && department.Students.Any())
                {
                    foreach(var student in department.Students)
                    {
                        Console.WriteLine("\t\t " + student.Name);
                    }
                }
                else
                {
                    Console.WriteLine("\t\t No Student Found!");
                }

            }

            var students = db.Students.Include(c=>c.Department).ToList();
            

            Console.ReadKey();
        }
    }
}

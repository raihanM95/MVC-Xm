using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVCApp.Models.Models;
using MyMVCApp.Repository.Repository;

namespace MyMVCApp.BLL.BLL
{
    public class StudentManager
    {
        StudentRepository _studentRepository = new StudentRepository();
        public bool Add(Student student)
        {
            return _studentRepository.Add(student);
        }
        public bool Add(List<Student> student)
        {
            return _studentRepository.Add(student);
        }
        public bool Delete(Student student)
        {
            return _studentRepository.Delete(student);
        }
        public bool Update(Student student)
        {
            return _studentRepository.Update(student);
        }
        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
        public Student GetByID(Student student)
        {
            return _studentRepository.GetByID(student.ID);
        }

        public Student GetByStudentId(int studentId)
        {
            return _studentRepository.GetByID(studentId);
        }

        public List<Student> GetByDistrict(int districtId)
        {
            return _studentRepository.GetByDistrict(districtId);
        }
    }
}

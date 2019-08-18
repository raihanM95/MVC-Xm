using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MyMVCApp.BLL.BLL;
using MyMVCApp.Models;
using MyMVCApp.Models.Models;

namespace MyMVCApp.Controllers
{
    public class StudentController : Controller
    {

        StudentManager _studentManager = new StudentManager();
        DistrictManager _districtManager = new DistrictManager();
        //
        // GET: /Student/
        [HttpGet]
        public ActionResult Add()
        {
            StudentAddVM StudentAddVM = new StudentAddVM();
            StudentAddVM.DistrictList = _districtManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });

            return View(StudentAddVM);
        }

        [HttpPost]
        public ActionResult Add(StudentAddVM StudentAddVM)
        {
            //string msg = "Failed";

            if (ModelState.IsValid)
            {

                var student = Mapper.Map<Student>(StudentAddVM);
                if (_studentManager.Add(student))
                {
                    ViewBag.SuccessMsg = "Saved!";
                }
                else
                {
                    ViewBag.ErrorMsg = "Failed!";
                }
            }
            else
            {
                ViewBag.ErrorMsg = "Validation!";
            }

            //StudentAddVM StudentAddVM = new StudentAddVM();
            StudentAddVM.DistrictList = _districtManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });

            return View(StudentAddVM);

        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            StudentAddVM StudentAddVM = new StudentAddVM();


            Student student = new Student();
           
            student = _studentManager.GetByID(Id);
            StudentAddVM = Mapper.Map<StudentAddVM>(student);

            StudentAddVM.DistrictList = _districtManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });

            return View(StudentAddVM);
        }

        [HttpPost]
        public ActionResult Delete(StudentAddVM StudentAddVM)
        {
            //string msg = "Failed";

            if (ModelState.IsValid)
            {
                var student = Mapper.Map<Student>(StudentAddVM);

                if (_studentManager.Delete(student))
                {
                    ViewBag.SuccessMsg = "Deleted!";
                }
                else
                {
                    ViewBag.ErrorMsg = "Failed!";
                }
            }
            else
            {
                ViewBag.ErrorMsg = "Validation!";
            }

            StudentAddVM.DistrictList = _districtManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });
            return View(StudentAddVM);

        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Student student = new Student();
            student.ID = Id;
            student = _studentManager.GetByID(Id);

            StudentAddVM StudentAddVM = new StudentAddVM();
            StudentAddVM = Mapper.Map<StudentAddVM>(student);

            StudentAddVM.DistrictList = _districtManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });
            return View(StudentAddVM);
        }

        [HttpPost]
        public ActionResult Edit(StudentAddVM studStudentAddVMent)
        {
            //string msg = "Failed";

            if (ModelState.IsValid)
            {
                var student = Mapper.Map<Student>(studStudentAddVMent);

                if (_studentManager.Update(student))
                {
                    ViewBag.SuccessMsg = "Updated!";
                }
                else
                {
                    ViewBag.ErrorMsg = "Failed!";
                }
            }
            else
            {
                ViewBag.ErrorMsg = "Validation!";
            }


            studStudentAddVMent.DistrictList = _districtManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });
            return View(studStudentAddVMent);

        }
        [HttpGet]
        public ActionResult Show()
        {
            StudentAddVM StudentAddVM = new StudentAddVM();

            StudentAddVM.Students = _studentManager.GetAll();
            StudentAddVM.DistrictList = _districtManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });
            return View(StudentAddVM);
        }

        [HttpPost]
        public ActionResult Show(StudentAddVM StudentAddVM)
        {

            var students = _studentManager.GetAll();

            if (StudentAddVM.Name != null)
            {
                //students = students.Where(c => c.Name.Contains(student.Name)).ToList();
                students = students.Where(c => c.Name.ToLower().Contains(StudentAddVM.Name.ToLower())).ToList();
            }
            if (StudentAddVM.Address != null)
            {
                //students = students.Where(c => c.Address.Contains(student.Address)).ToList();
                students = students.Where(c => c.Address.ToLower().Contains(StudentAddVM.Address.ToLower())).ToList();
            }
            if (StudentAddVM.Contact != null)
            {
                //students = students.Where(c => c.Contact.Contains(student.Contact)).ToList();
                students = students.Where(c => c.Contact.ToLower().Contains(StudentAddVM.Contact.ToLower())).ToList();
            }
            if (StudentAddVM.Age > 0)
            {
                students = students.Where(c => c.Age == StudentAddVM.Age).ToList();
            }

            StudentAddVM.Students = students;
            StudentAddVM.DistrictList = _districtManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });
            return View(StudentAddVM);
        }


        public ActionResult Details()
        {
            var districts = _districtManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                }).ToList();


            districts.Insert(0,new SelectListItem()
            {
                Value="",
                Text = "Select..."
            });


            ViewBag.District = districts;

            return View();
        }

        
        public JsonResult GetByDistrict(int districtId)
        {
            var students = _studentManager.GetByDistrict(districtId);

            return Json(students,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByName(string name)
        {
            var student = _studentManager.GetByName(name);

            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStudentPartial(int studentId)
        {
            var student = _studentManager.GetByID(studentId);

            return PartialView("Student/_StudentDetail", student);
        }

    }
}
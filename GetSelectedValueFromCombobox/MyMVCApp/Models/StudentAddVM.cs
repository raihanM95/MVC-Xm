using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCApp.Models.Models;

namespace MyMVCApp.Models
{
    public class StudentAddVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }

        [DisplayName("District")]
        public int DistrictID { get; set; }

        public IEnumerable<SelectListItem> DistrictList { get; set; }
        
        public List<Student> Students { get; set; }
    }
}
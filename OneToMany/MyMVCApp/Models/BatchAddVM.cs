using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCApp.Models.Models;

namespace MyMVCApp.Models
{
    public class BatchAddVM
    {
        public int DistrictID { set; get; }
        public List<Student> Students { set; get; }
        public List<SelectListItem> DistrictList { set; get; }

        

    }
}
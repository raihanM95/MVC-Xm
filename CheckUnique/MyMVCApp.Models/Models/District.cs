using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVCApp.Models.Models
{
    public class District
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}

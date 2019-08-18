using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLoadingRelatedData.Models
{
    public class Department
    {
        public Department()
        {
            Students = new List<Student>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}

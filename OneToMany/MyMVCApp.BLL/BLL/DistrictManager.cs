using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVCApp.Models.Models;
using MyMVCApp.Repository.Repository;

namespace MyMVCApp.BLL.BLL
{
    public class DistrictManager
    {
        District _district = new District();
        DistrictRepository _districtRepository = new DistrictRepository();

        public bool Add(District _district)
        {
            return _districtRepository.Add(_district);
        }
        public bool Delete(District _district)
        {
            return _districtRepository.Delete(_district);
        }
        public bool Update(District _district)
        {
            return _districtRepository.Update(_district);
        }

        public List<District> GetAll()
        {
            return _districtRepository.GetAll();
        }
        public District GetByID(District District)
        {
            return _districtRepository.GetByID(District);
        }

    }
}

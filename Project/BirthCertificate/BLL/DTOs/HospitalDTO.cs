using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class HospitalDTO
    {
        public string HospitalName { get; set; }
        public string HospitalLocation { get; set; }
        public int HospitalCode { get; set; }
        public string TimeofBirth { get; set; }
        public int HospitalID { get; set; }

        //public virtual Children_information Children_information { get; set; }
    }
}

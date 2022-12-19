using DAL.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class HospitalEmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Vinfo { get; set; }

        //public virtual VolInfo VolInfo { get; set; }
    }
}

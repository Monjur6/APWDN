using DAL.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class VolenteerDTO
    {
        //public VolInfo()
        //{
        //    this.HospitalEmployees = new HashSet<HospitalEmployee>();
        //}

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Gender { get; set; }

        //public virtual ICollection<HospitalEmployee> HospitalEmployees { get; set; }
    }
}

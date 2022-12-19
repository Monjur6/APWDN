using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int id { get; set; }
        public int BirthRegistrationNumber { get; set; }
        public System.DateTime Createdat { get; set; }
        public System.DateTime Expireat { get; set; }
        public string tokenaccess { get; set; }

  
    }
}

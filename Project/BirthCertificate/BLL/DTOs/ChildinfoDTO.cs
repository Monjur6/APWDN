using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ChildinfoDTO
    {
        public string ChildrenName { get; set; }
        public string Dateofbirth { get; set; }
        public int BirthRegistrationNumber { get; set; }
        public string placeofbirth { get; set; }
        public string FatherNmae { get; set; }
        public string MotherName { get; set; }
        public string parmanentAddress { get; set; }
        public string FatherNationality { get; set; }
        public string MotherNationality { get; set; }
        public int CHILDID { get; set; }
    }
}


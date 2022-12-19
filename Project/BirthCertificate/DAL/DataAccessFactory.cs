using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static BIRTHEntities db = new BIRTHEntities();
        public static IAuth AuthDataAccess()
        {
            return new AuthRepo(db);
        }
        public static IRepo<Children_information, int, Children_information> ChildDataAccess()
        {
            return new BIRTHREGISTER();
        }
        public static IRepo<Hosital_information, int, bool> HospitalDataAccess()
        {
            return new HospitalRepo();
        }
      

     


        public static IRepo<VolInfo, int, bool> VolenteerDataAccess()
        {
            return new VolenteerRepo();
        }
        public static IRepo<HospitalEmployee, int, HospitalEmployee> HospitalEmployeeDataAccess()
        {
            return new HospitalEmployeeRepo();
        }
        public static IRepo<Employee, string, Employee> EmployeeDataAccess()
        {
            return new EmployeeRepo();
        }
        public static EAuth EAuthDataAccess()
        {
            return new EmployeeRepo();
        }
    }
}
    

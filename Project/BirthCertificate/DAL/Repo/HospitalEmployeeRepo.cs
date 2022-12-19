using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    class HospitalEmployeeRepo : IRepo<HospitalEmployee, int, HospitalEmployee>
    {
        BIRTHEntities db;
        internal HospitalEmployeeRepo()
        {
            db = new BIRTHEntities();
        }
        public HospitalEmployee Add(HospitalEmployee obj)
        {
            db.HospitalEmployees.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public HospitalEmployee Authenticate(string uname, string password)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            db.HospitalEmployees.Remove(db.HospitalEmployees.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<HospitalEmployee> Get()
        {
            return db.HospitalEmployees.ToList();
        }

        public HospitalEmployee Get(int id)
        {
            return db.HospitalEmployees.Find(id);
        }

        public bool Update(HospitalEmployee obj)
        {
            var ext = db.HospitalEmployees.Find(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;

        }
    }
}



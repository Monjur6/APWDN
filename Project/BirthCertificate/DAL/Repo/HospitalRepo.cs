using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class HospitalRepo : IRepo<Hosital_information, int, bool>
    {
      
        BIRTHEntities db;
        internal HospitalRepo()
        {
            db = new BIRTHEntities();
        }

        public bool Add(Hosital_information obj)
        {
            db.Hosital_information.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Hosital_information Authenticate(string uname, string password)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var ext = db.Hosital_information.Find(id);
            db.Hosital_information.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<Hosital_information> Get()
        {
            return db.Hosital_information.ToList();
        }

        public Hosital_information Get(int id)
        {
            return db.Hosital_information.Find(id);
        }

        public bool Update(Hosital_information obj)
        {
            var ext = Get(obj.HospitalID);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}




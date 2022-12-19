using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class BIRTHREGISTER : IRepo<Children_information, int, Children_information>
    {
        BIRTHEntities db;
        internal BIRTHREGISTER()
        {
            db = new BIRTHEntities();
        }
        public Children_information Add(Children_information obj)
        {
            db.Children_information.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Children_information Authenticate(string uname, string password)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            db.Children_information.Remove(db.Children_information.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Children_information> Get()
        {
            return db.Children_information.ToList();
        }

        public Children_information Get(int id)
        {
            return db.Children_information.Find(id);
        }

        public bool Update(Children_information obj)
        {
            var ext = db.Children_information.Find(obj.BirthRegistrationNumber);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}


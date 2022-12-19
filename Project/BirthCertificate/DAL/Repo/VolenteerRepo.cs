using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class VolenteerRepo : IRepo<VolInfo, int, bool>
    {
        BIRTHEntities db;
        internal VolenteerRepo()
        {
            db = new BIRTHEntities();
        }
        public bool Add(VolInfo obj)
        {
            db.VolInfoes.Add(obj);
            return db.SaveChanges() > 0;
        }

        public VolInfo Authenticate(string uname, string password)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var ext = db.VolInfoes.Find(id);
            db.VolInfoes.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<VolInfo> Get()
        {
            return db.VolInfoes.ToList();
        }

        public VolInfo Get(int id)
        {
            return db.VolInfoes.Find(id);
        }

        public bool Update(VolInfo obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
      
    }
}

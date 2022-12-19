using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    class EmployeeRepo : IRepo<Employee, string, Employee>, EAuth
    {
        BIRTHEntities db;
        internal EmployeeRepo()
        {
            db = new BIRTHEntities();
        }
        public Employee Add(Employee obj)
        {
            db.Employees.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Employee Authenticate(string uname, string password)
        {
            throw null;
        }

        public bool Delete(string id)
        {
            db.Employees.Remove(db.Employees.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee Get(string id)
        {
            return db.Employees.Find(id);
        }

        public bool Update(Employee obj)
        {
            var ext = db.Employees.Find(obj.Name);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

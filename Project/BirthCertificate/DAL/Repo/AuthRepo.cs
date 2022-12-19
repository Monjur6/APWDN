using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class AuthRepo : IAuth
    {
        BIRTHEntities db;

        public AuthRepo(BIRTHEntities db)
        {
            this.db = db;
        }
        public Token Authenticate(string ChildrenName, string Dateofbirrh)
        {
            var u = db.Children_information.FirstOrDefault(e => e.ChildrenName == ChildrenName && e.Dateofbirth == Dateofbirrh);
            if (u != null)
            {

                var g = Guid.NewGuid();
                var token = g.ToString();
                var t = new Token()
                {
                    BirthRegistrationNumber = u.BirthRegistrationNumber,
                    tokenaccess = token,
                    Createdat = DateTime.Now,
                    Expireat = DateTime.Now.AddMinutes(10)
                };
                db.Tokens.Add(t);
                db.SaveChanges();
                return t;
            }
            else
            {
                return null;
            }
        }

        public bool IsAuthenticated(string token)
        {
            var ac_token = db.Tokens.FirstOrDefault(e => e.tokenaccess.Equals(token) && e.Expireat == null);
            if (ac_token != null) return true;
            return false;
        }

        public bool Logout(int id)
        {
            var data = db.Tokens.FirstOrDefault(e => e.BirthRegistrationNumber == id);
            if (data != null)
            {
                db.Tokens.Remove(data);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuth
    {
        Token Authenticate(string ChildrenName, string Dateofbirrh);
        bool IsAuthenticated(string token);
        bool Logout(int id);
    }
}

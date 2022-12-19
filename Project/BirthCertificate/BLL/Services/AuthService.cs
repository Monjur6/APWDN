using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string ChildrenName, string Dateofbirrh)
        {
            var data = DataAccessFactory.AuthDataAccess().Authenticate(ChildrenName, Dateofbirrh);
            if (data != null)
            {
                TokenDTO tokendto = new TokenDTO()
                {
                   id= data.id, 
                   tokenaccess=data.tokenaccess,
                   Createdat=data.Createdat,
                   Expireat=data.Expireat,
                   BirthRegistrationNumber=data.BirthRegistrationNumber,

                };
                return tokendto;
            }
            return null;
        }
        public static bool CheckValidityToken(string token)
        {
            var authCheck = DataAccessFactory.AuthDataAccess().IsAuthenticated(token);
            return authCheck;
        }
        public static bool Logout(int uid)
        {
            var logout = DataAccessFactory.AuthDataAccess().Logout(uid);
            return logout;
        }
    }
    }



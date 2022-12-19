using BLL.DTOs;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BirthCertificate.Controllers
{
    public class AuthController : ApiController
    {

        
        [Route("api/Auth/login")]
        [HttpPost]
        public HttpResponseMessage Login(UserDTO u)
        {
            var data = AuthService.Authenticate(u.ChildrenName, u.Dateofbirth); 
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Username Or Password Invalid");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        
        [Route("api/Auth/logout/{uid}")]
        [HttpGet]
        public HttpResponseMessage Logout(int uid)
        {
            var data = AuthService.Logout(uid);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully Logged Out");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Already Loggedout");
        }
    }
}


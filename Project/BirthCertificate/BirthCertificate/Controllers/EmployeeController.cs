using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BirthCertificate.Controllers
{
    public class EmployeeController : ApiController
    {
        [Route("api/employees")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = EmployeeService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/employees/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var data = EmployeeService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/employees/add")]
        [HttpPost]
        public HttpResponseMessage Add(EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                var data = EmployeeService.Add(employee);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        [Route("api/employees/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(string id)
        {
            var data = EmployeeService.Delete(id);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = "Successfully deleted"
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new
                {
                    Message = "Unsuccessfully deleted"
                });
            }
        }
        [Route("api/employees/update")]
        [HttpPost]
        public HttpResponseMessage Update(EmployeeDTO dto)
        {
            var data = EmployeeService.Update(dto);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = "Successfully updated"
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new
                {
                    Message = "Unsuccessfully updated"
                });
            }
        }
    }
}

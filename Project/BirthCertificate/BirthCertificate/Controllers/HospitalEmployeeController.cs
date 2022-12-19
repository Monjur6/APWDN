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
    public class HospitalEmployeeController : ApiController
    {
        [Route("api/hospitalemployees")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = HospitalEmployeeService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/hospitalemployees/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = HospitalEmployeeService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/hospitalemployees/add")]
        [HttpPost]  
        public HttpResponseMessage Add(HospitalEmployeeDTO hospitalEmployee)
        {
            if (ModelState.IsValid)
            {
                var data = HospitalEmployeeService.Add(hospitalEmployee);
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
        [Route("api/hospitalemployees/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var data = HospitalEmployeeService.Delete(id);
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
        [Route("api/hospitalemployees/update")]
        [HttpPost]
        public HttpResponseMessage Update(HospitalEmployeeDTO dto)
        {
            var data = HospitalEmployeeService.Update(dto);
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

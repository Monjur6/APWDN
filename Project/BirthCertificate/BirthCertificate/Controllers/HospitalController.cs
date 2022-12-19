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
    public class HospitalController : ApiController
    {
        [Route("api/hospital")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = HospitalService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/hospital/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = HospitalService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/hospital/add")]
        [HttpPost]
        public HttpResponseMessage Post(HospitalDTO   hospitaL)
        {
            {
                var data = HospitalService.Add(hospitaL);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Message = "Successfully created"
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, new
                    {
                        Message = "Unsuccessfully created"
                    });
                }
            }

        }
        [Route("api/hospital/update")]
        [HttpPost]
        public HttpResponseMessage Update(HospitalDTO dto)
        {
            var data = HospitalService.Update(dto);
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

        [Route("api/hospital/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var data = HospitalService.Delete(id);
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

    }
}


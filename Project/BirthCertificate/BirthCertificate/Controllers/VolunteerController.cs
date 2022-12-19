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
    public class VolunteerController : ApiController
    {
        [Route("api/volunteers")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = VolenteerService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/volunteers/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = VolenteerService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/volunteers/add")]
        [HttpPost]
        public HttpResponseMessage Post(VolenteerDTO volenteer)
        {
            if (ModelState.IsValid)
            {
                var resp = VolenteerService.Add(volenteer);
                if (resp)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Inserted", data = volenteer });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        [Route("api/volunteers/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var data = VolenteerService.Delete(id);
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
        [Route("api/volunteers/update")]
        [HttpPost]
        public HttpResponseMessage Update(VolenteerDTO dto)
        {
            var data = VolenteerService.Update(dto);
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

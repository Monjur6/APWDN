using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BirthCertificate.Controllers
{
    public class ChildController : ApiController
    {


        [Route("api/child")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = ChildService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/child/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = ChildService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/child/add")]
        [HttpPost]
        public HttpResponseMessage Add(ChildinfoDTO child)
        {
            if (ModelState.IsValid)
            {
                var data = ChildService.Add(child);
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

        [Route("api/child/update")]
        [HttpPost]
        public HttpResponseMessage Update(ChildinfoDTO dto)
        {
            var data = ChildService.Update(dto);
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

        [Route("api/child/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var data = ChildService.Delete(id);
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
    


using MediaForAll.Web.Domain;
using MediaForAll.Web.Models;
using MediaForAll.Web.Models.Responses;
using MediaForAll.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediaForAll.Web.Controllers
{
    [RoutePrefix("api/Job")]
    public class JobApiController : ApiController
    {
        IJobService _jobService = null;
        public JobApiController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage CreateJob(JobAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            int id = _jobService.Insert(model);
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = id;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAllJobs()
        {
            ItemResponse<List<Job>> response = new ItemResponse<List<Job>>();
            response.Item = _jobService.GetAllJobs();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public HttpResponseMessage DeleteDocument(int id)
        {
            _jobService.Delete(id);
            SuccessResponse response = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}

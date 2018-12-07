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
    [RoutePrefix("api/JobApplication")]
    public class JobApplicationApiController : ApiController
    {
        IJobApplicationService _jobApplicationService = null;
        public JobApplicationApiController(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage CreateJob(JobApplicationAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            int id = _jobApplicationService.Insert(model);
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = id;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAllJobApplications()
        {
            ItemResponse<List<JobApplication>> response = new ItemResponse<List<JobApplication>>();
            response.Item = _jobApplicationService.GetAllJobApplications();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("Delete/{ApplicantKey:int}/{JobKey:int}")]
        public HttpResponseMessage DeleteJobApplication(int ApplicantKey, int JobKey)
        {
            _jobApplicationService.Delete(ApplicantKey, JobKey);
            SuccessResponse response = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetJobApplicationById(int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<JobApplication> response = new ItemResponse<JobApplication>();
            response.Item = _jobApplicationService.GetJobApplicationById(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


    }
}

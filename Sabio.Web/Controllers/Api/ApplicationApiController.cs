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
    [RoutePrefix("api/Application")]
    public class ApplicationApiController : ApiController
    {
        IApplicationService _applicationService = null;
        public ApplicationApiController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage CreateApplication(ApplicationAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            int id = _applicationService.Insert(model);
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = id;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAllDocuments()
        {
            ItemResponse<List<Applicant>> response = new ItemResponse<List<Applicant>>();
            response.Item = _applicationService.GetAllApplicants();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetApplicantById(int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<Applicant> response = new ItemResponse<Applicant>();
            response.Item = _applicationService.GetApplicantById(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [Route()]
        [HttpPut]
        public HttpResponseMessage UpdateApplicant(ApplicationUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            _applicationService.Update(model);
            SuccessResponse response = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }





    }
}

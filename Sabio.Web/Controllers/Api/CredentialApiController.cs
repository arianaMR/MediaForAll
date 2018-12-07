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
    [RoutePrefix("api/Credential")]
    public class CredentialApiController : ApiController
    {
        ICredentialService _credentialService = null;
        public CredentialApiController(ICredentialService credentialService)
        {
            _credentialService = credentialService;
        }


        [HttpGet]
        [Route("{userName}")]
        public HttpResponseMessage GetPasswordById(string userName)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<Credential> response = new ItemResponse<Credential>();
            response.Item = _credentialService.GetPasswordById(userName);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAllUserNames()
        {
            ItemResponse<List<string>> response = new ItemResponse<List<string>>();
            response.Item = _credentialService.GetAllUserNames();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [Route()]
        [HttpPut]
        public HttpResponseMessage UpdatePassword(PasswordUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _credentialService.UpdatePassword(model);
            SuccessResponse response = new SuccessResponse();
            
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


    }
}

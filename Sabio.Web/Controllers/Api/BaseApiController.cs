using MediaForAll.Web.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace MediaForAll.Web.Controllers.Api
{
    public class BaseApiController : ApiController
    {
        public HttpResponseMessage ErrorList(ICollection<ModelState> errorItems) {

            List<string> errors = new List<string>();

            foreach (ModelState state in errorItems)
            {
                foreach (ModelError error in state.Errors)
                {
                    if (error.ErrorMessage.Length > 0)
                        errors.Add(error.ErrorMessage);
                    if (error.Exception != null && error.Exception.Message.Length > 0)
                        errors.Add(error.Exception.Message);
                }
            }
            ErrorResponse response = new ErrorResponse(errors);
            return Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }

        public HttpResponseMessage ExpectationFailedError(string message)
        {

            ErrorResponse response = new ErrorResponse(message);
            return Request.CreateResponse(HttpStatusCode.ExpectationFailed, response);
            
        }
    }
}

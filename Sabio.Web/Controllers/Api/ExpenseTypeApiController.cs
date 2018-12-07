using Sabio.Web.Domain;
using Sabio.Web.Models.Requests;
using Sabio.Web.Models.Responses;
using Sabio.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sabio.Web.Controllers.Api
{
    [RoutePrefix("api/expenseType")]
    public class ExpenseTypeApiController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetAll()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            ItemsResponse<ExpenseType> response = new ItemsResponse<ExpenseType>();
            response.Items = ExpenseService.GetAllExpenseType();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            ItemResponse<ExpenseType> response = new ItemResponse<ExpenseType>();
            response.Item = ExpenseService.GetExpenseTypeById(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
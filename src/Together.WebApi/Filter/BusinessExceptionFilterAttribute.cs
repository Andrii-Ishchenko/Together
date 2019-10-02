using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using Together.Services.Exceptions;

namespace Together.WebApi.Filter
{
    public class BusinessExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            BusinessException exception = actionExecutedContext?.Exception as BusinessException;
            if (exception != null)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(exception.HttpStatusCode, exception.Message);
            }

            return Task.FromResult<object>(null);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RovisianServerDev.Domain.Error;
using System.Net;

namespace RovisianServerDev.Infrastructure.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(DataNotFoundException))
            {
                var exception = (DataNotFoundException)context.Exception;

                var validation = new
                {
                    Estatus = (int)HttpStatusCode.NotFound,
                    Title = "Data Not Found",
                    Detail = exception.Message,
                };


                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.ExceptionHandled = true;
            }


            if (context.Exception.GetType() == typeof(ParamNullException))
            {
                var exception = (ParamNullException)context.Exception;

                var validation = new
                {
                    Estatus = (int)HttpStatusCode.BadRequest,
                    Title = "Data Null",
                    Detail = exception.Message,
                };


                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}

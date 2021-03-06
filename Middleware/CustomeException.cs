using KarKhanaBook.Model.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static KarKhanaBook.Model.Common.Result;

namespace KarKhanaBook.Middleware
{
    public class CustomeException
    {
        private readonly RequestDelegate _next;
       
        public CustomeException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Result result = new Result();
            var hasError = false;

            try
            {
                await _next(context);
            }

            catch (ArgumentException e)
            {
                hasError = true;
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = new Result()
                {
                    Message = e.Message,
                    Status = ((ResultStatus)(Enum.Parse(typeof(ResultStatus), ResultStatus.warning.ToString()
                    , true))).ToString(),
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            catch (MethodAccessException e)
            {

                hasError = true;
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.NotModified;
                result = new Result()
                {
                    Message = e.Message,
                    Status = ((ResultStatus)(Enum.Parse(typeof(ResultStatus), ResultStatus.warning.ToString()
                    , true))).ToString(),
                    StatusCode = (int)HttpStatusCode.NotModified
                };
            }
            catch (UnauthorizedAccessException e)
            {

                hasError = true;
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = new Result()
                {
                    Message = e.Message,
                    Status = ((ResultStatus)(Enum.Parse(typeof(ResultStatus), ResultStatus.warning.ToString()
                    , true))).ToString(),
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            catch (Exception e)
            {

                hasError = true;
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = new Result()
                {
                    Message = e.Message,
                    Status = ((ResultStatus)(Enum.Parse(typeof(ResultStatus), ResultStatus.warning.ToString()
                    , true))).ToString(),
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            finally
            {
                if (hasError == true)
                {
                    var errorJson = JsonConvert.SerializeObject(result);
                    await context.Response.WriteAsync(errorJson);
                }
            }
        }
    }
}

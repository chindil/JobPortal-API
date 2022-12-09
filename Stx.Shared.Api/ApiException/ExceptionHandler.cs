using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Stx.Shared.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Stx.Shared;
using System.Net.Http;
using System.Text.Json;
using System.Diagnostics;
using Stx.Shared.Exceptions;

namespace Stx.Shared.Api.ApiException
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
            _next = next;
        }

        //[DebuggerNonUserCode]
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (StxHttpResponseException sx)
            {
                _logger.LogError($"Something went wrong: {sx}");
                await HandleExceptionAsync(httpContext, null, sx);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, StxHttpResponseException stxException=null)
        {
            context.Response.ContentType = "application/json";
            if (stxException == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.WriteAsync(
                     JsonSerializer.Serialize(
                    new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error. " + exception.Message
                    }));
            }
            else
            {
                context.Response.StatusCode = (int)stxException.StatusCode;
                return context.Response.WriteAsync(
                    JsonSerializer.Serialize(
                    new ErrorDetails()
                    {
                        StatusCode = (int)stxException.StatusCode,
                        Message = string.IsNullOrWhiteSpace(stxException.PublicMessage) ? "Internal Server Error. " + exception.Message : stxException.PublicMessage
                    }));
            }
        }
    }


}

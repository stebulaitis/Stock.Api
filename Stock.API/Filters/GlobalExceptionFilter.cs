using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Stock.Core.Exceptions;
using Stock.Core.Models;
using System.Text.Json;
using Stock.Core.Extensions;

namespace Stock.API.Filters
{
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            bool useDefaultResponseMessage = true;

            context.ExceptionHandled = true;

            if (context.Exception is DomainException)
            {
                SetJsonResult(context, StatusCodes.Status400BadRequest, new ErrorResponse(context.Exception.Message), LogLevel.Warning);
            }
            else if (context.Exception is DomainValidationException)
            {
                SetJsonResult(context, StatusCodes.Status400BadRequest, new ErrorResponse((context.Exception as DomainValidationException).ErrorMessages?.ToList()), LogLevel.Information);
            }
            else if (context.Exception is DomainNotFoundException)
            {
                SetJsonResult(context, StatusCodes.Status404NotFound, new ErrorResponse(context.Exception.Message), LogLevel.Information);
            }
            else if (context.Exception is FlurlHttpException flurlException)
            {
                var error = await flurlException.GetFlurlErrorResponse();

                SetJsonResult(context, flurlException.Call.Response.StatusCode, error, LogLevel.Error);
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                SetJsonResult(context, StatusCodes.Status401Unauthorized, new ErrorResponse(context.Exception.Message), LogLevel.Information);
            }
            else
            {
                SetJsonResult(context, StatusCodes.Status500InternalServerError, new ErrorResponse("Infelizmente ocorreu um erro ao processar sua solicitação."), LogLevel.Error);
            }
        }

        private void SetJsonResult(ExceptionContext context, int status, ErrorResponse error, LogLevel logLevel)
        {
            WriteLog(context, error, logLevel);

            context.Result = new JsonResult(error) { StatusCode = status };
        }

        private void WriteLog(ExceptionContext context, ErrorResponse error, LogLevel logLevel)
        {
            const string logTemplate = "{requestProtocol} {method} {requestPath} Error Message: {errorData}";

            var jsonError = JsonSerializer.Serialize(error);

            if (logLevel == LogLevel.Information)
            {
                _logger.LogInformation(context.Exception, logTemplate, context.HttpContext.Request.Protocol, context.HttpContext.Request.Method, context.HttpContext.Request.Path, jsonError);
            }
            else if (logLevel == LogLevel.Warning)
            {
                _logger.LogWarning(context.Exception, logTemplate, context.HttpContext.Request.Protocol, context.HttpContext.Request.Method, context.HttpContext.Request.Path, jsonError);
            }
            else if (logLevel == LogLevel.Error)
            {
                _logger.LogError(context.Exception, logTemplate, context.HttpContext.Request.Protocol, context.HttpContext.Request.Method, context.HttpContext.Request.Path, jsonError);
            }
        }
    }
}

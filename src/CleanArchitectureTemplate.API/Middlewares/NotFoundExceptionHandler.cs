using CleanArchitectureTemplate.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.API.Middlewares;

public class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not NotFoundException notFoundException)
        {
            return false;
        }
        
        logger.LogError(
            notFoundException,
            "Exception occurred: {Message}",
            notFoundException.Message);
        
        var problemDetails = new ProblemDetails
        {
            Type = exception.GetType().Name,
            Status = StatusCodes.Status404NotFound,
            Title = "Not Found",
            Detail = notFoundException.Message
        };
        
        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
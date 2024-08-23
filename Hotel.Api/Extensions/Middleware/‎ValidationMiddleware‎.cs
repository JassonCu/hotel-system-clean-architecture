using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Hotel.UseCases.Commons.Bases;
using Hotel.Utils.Constants;

namespace Hotel.Api.Extensions.Middleware;

public class ValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
            {
                Message = GlobalMessage.MESSAGE_VALIDATE,
            });
        }
    }

}

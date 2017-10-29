using Microsoft.AspNetCore.Mvc;

namespace AutoRespect.Infrastructure.ErrorHandling.AspNetCore
{
    public static class ResultExtension
    {
        public static IActionResult AsActionResult<T>(this Result<T> result)
        {
            if (result.IsSuccess)
                return new OkObjectResult(result.Value);
            else
                return new BadRequestObjectResult(result.Failures);
        }
    }
}

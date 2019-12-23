using BeierSeguros.Shared.Contracts;
using BeierSeguros.Shared.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace BeierSeguros.Api.Controllers
{
    public abstract class BaseApiController : Controller
    {
        protected new IActionResult Response(Result result, object output = null)
        {
            if (result.Success)
            {
                return Ok(new
                {
                    success = result.Success,
                    message = result.Message,
                    data = output ?? result.Data
                });
            }

            return BadRequest(new
            {
                success = result.Success,
                message = result.Message,
                errors = result.Errors
            });
        }

        protected new IActionResult Response(INotifiable notifiable, object output = null)
        {
            if (!notifiable.HasErrors)
            {
                return Ok(new
                {
                    success = true,
                    message = notifiable.Message,
                    data = output ?? notifiable.Data
                });
            }

            return BadRequest(new
            {
                success = false,
                message = notifiable.Message,
                errors = notifiable.Errors
            });
        }
    }
}

using ContactUs.API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactUs.API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController
    {
        public ActionResult Error(int code)
        {
            return new ObjectResult(new ApiErroeResponse(code));
        }
    }
}

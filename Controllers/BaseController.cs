
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChallangeBackend.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseResponse<T> SetStatusCode<T>(BaseResponse<T> response)
        {
            if (response.Error != null)
                Response.StatusCode = 400;

            if (response.StatusCode != 200)
                Response.StatusCode = response.StatusCode;

            return response;
        }
    }
}

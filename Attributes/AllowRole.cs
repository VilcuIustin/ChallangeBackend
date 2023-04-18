using Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace ChallangeBackend.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class AllowRole : ActionFilterAttribute
    {
        private readonly RoleType _roleType;
        private readonly string _errorMsg = "Not allowed";

        public AllowRole(RoleType roleType)
        {
            _roleType = roleType;
        }

        public AllowRole(RoleType roleType, string errorMsg)
        {
            _roleType = roleType;
            _errorMsg = errorMsg;

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var roles = context.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Role.ToString())?
                .Select(r => r.Value).ToList();

            foreach (var role in roles)
            {
                if (_roleType.HasFlag(Enum.Parse<RoleType>(role)))
                    return;
            }

            context.Result = new UnauthorizedObjectResult(
                    new { Message = _errorMsg });
        }

    }
}

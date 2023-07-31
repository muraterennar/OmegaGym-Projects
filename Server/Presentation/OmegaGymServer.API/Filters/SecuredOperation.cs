using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.CustomAttributes;

namespace OmegaGymServer.API.Filters;

public class SecuredOperation : IAsyncActionFilter
{
    readonly IUserService _userService;

    public SecuredOperation(IUserService userService)
    {
        _userService = userService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var name = context.HttpContext.User.Identity?.Name; var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
        var attribute = descriptor.MethodInfo.GetCustomAttribute(typeof(AuthorizeDefinationAttribute)) as AuthorizeDefinationAttribute;
        if (!string.IsNullOrEmpty(name))
        {
            var hasRole = await _userService.HasRolePermissionToRoleNameAsync(name, attribute.Roles);

            if (!hasRole)
                context.Result = new UnauthorizedResult();
            else
                await next();
        }
        else
        {
            await next();
        }
    }
}


using BulbEd.Extensions;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BulbEd.Helpers;

//This is a filter that will be applied to all the controllers, it will update the last active property of the user
public class LogUserActivity : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        var resultContext = await next();

        if (resultContext.HttpContext.User.Identity is { IsAuthenticated: false }) return;
        
        var userId = resultContext.HttpContext.User.GetUserId();
        
        var uow = resultContext.HttpContext.RequestServices.GetService<IUnitOfWork>();
        
        var user = await uow.UserRepository.GetUserByIdAsync(userId);
        
        user.LastActive = DateTime.UtcNow;
        
        await uow.Complete();
    }
}
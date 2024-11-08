using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.IO;

public class UniqueUserFilter : IActionFilter
{
    private static HashSet<string> uniqueUsers = new HashSet<string>();

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var userIpAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();
        if (!string.IsNullOrEmpty(userIpAddress) && uniqueUsers.Add(userIpAddress))
        {
            File.WriteAllText("unique_user_count.txt", uniqueUsers.Count.ToString());
            File.WriteAllText("unique_user_count.txt", $"Unique users: {uniqueUsers.Count}");
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}

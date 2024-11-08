using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

public class LogActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var methodName = context.ActionDescriptor.DisplayName;
        var logMessage = $"Метод: {methodName}, Час: {DateTime.Now}\n";
        File.AppendAllText("action_log.txt", logMessage);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}

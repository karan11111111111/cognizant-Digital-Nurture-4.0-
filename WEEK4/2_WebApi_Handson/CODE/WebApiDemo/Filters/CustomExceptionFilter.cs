using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace WebApiDemo.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly string _logFilePath = "errorlog.txt";

        public void OnException(ExceptionContext context)
        {
            // Log the exception
            File.AppendAllText(_logFilePath, $"{DateTime.Now}: {context.Exception}\n");

            // Set the result
            context.Result = new ObjectResult(new
            {
                error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            })
            {
                StatusCode = 500
            };
        }
    }
}
public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var errorMessage = $"Error: {context.Exception.Message}\nStack Trace: {context.Exception.StackTrace}";
        File.WriteAllText("error.log", errorMessage);
        context.Result = new ObjectResult("Internal Server Error")
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}
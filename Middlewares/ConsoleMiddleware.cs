
public class ConsoleMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine($"Before Request");
        await next(context);
        Console.WriteLine($"After Request");
    }
}
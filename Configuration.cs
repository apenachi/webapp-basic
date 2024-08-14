public static class Configuration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services
               .AddEndpointsApiExplorer()
               .AddSwaggerGen()
               .AddTransient<ConsoleMiddleware>(); // Custom Middleware Registration
    }

    public static void RegisterMiddlewares(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger()
               .UseSwaggerUI()
               .UseMiddleware<ConsoleMiddleware>(); // Custom Middleware Use
        }
        app.UseHttpsRedirection();

    }
}
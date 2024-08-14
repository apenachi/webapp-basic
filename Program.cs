var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.RegisterServices();

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
// app.UseHttpsRedirection();

app.RegisterMiddlewares();
app.RegisterEndpoints();

// Create a logger
var logger = app.Services.GetRequiredService<ILogger<Program>>();


// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };
// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();

//     logger.LogInformation("Weather forecast generated.");
//     return forecast;
// })
// .Produces(StatusCodes.Status200OK)
// .WithName("GetWeatherForecast")
// .WithOpenApi();

/** Move to ConsoleMiddleware */
// app.Use(async (ctx, next) => {
//     Console.WriteLine($"Before Request");
//     await next();
//     Console.WriteLine($"After Request");
//     });

// Terminal Middleware : meaning it handles the request and generates the response without passing the request to any further middleware.
// That's why we need to call app.run() to continue the request pipeline.
// app.Run(async context => {
//     await context.Response.WriteAsync("Hello, World!");
// });


app.Run();
// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

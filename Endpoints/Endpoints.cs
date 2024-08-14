public static class Endpoints
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder routes)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var weather = routes.MapGroup("/api/v1/weather");
                        // .RequireAuthorization(); //will apply to all routes in this group

        weather.MapGet("", () =>
        {
            var forecast =  Enumerable.Range(1, 5).Select(index =>
                new Weather
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();

            return forecast;
        })
        .Produces(StatusCodes.Status200OK)
        .WithName("GetWeather")
        .WithSummary("Get the weather forecast.")
        .WithOpenApi();
    }
    record Weather(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging((hostingContext, loggingBuilder) =>
{
    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});


var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();

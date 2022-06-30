using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot()
                .AddCacheManager(settings => settings.WithDictionaryHandle());

builder.Host.ConfigureLogging((hostingContext, loggingBuilder) =>
{
    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json",true,true);
});

var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.UseOcelot();

app.Run();

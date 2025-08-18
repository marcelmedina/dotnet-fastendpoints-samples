using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsSamples.Processors;
using System.Reflection;

var builder = WebApplication.CreateBuilder();
builder.Services
    .AddFastEndpoints(o =>
    {
        o.Assemblies = [Assembly.GetExecutingAssembly()]; // To avoid: System.InvalidOperationException: 'FastEndpoints was unable to find any endpoint declarations!'
    })
    .SwaggerDocument(); //define a swagger document

var app = builder.Build();
app
    .UseFastEndpoints(c =>
    {
        c.Endpoints.Configurator = ep =>
        {
            ep.PreProcessor<GlobalTenantIdChecker>(Order.Before);
        };
    })
    .UseSwaggerGen();
app.Run();
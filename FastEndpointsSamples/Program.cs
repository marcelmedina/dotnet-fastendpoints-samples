using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsSamples.Extensions;
using NSwag;
using System.Reflection;

var builder = WebApplication.CreateBuilder();
builder.Services
    .AddFastEndpoints(o =>
    {
        o.Assemblies = [Assembly.GetExecutingAssembly()]; // To avoid: System.InvalidOperationException: 'FastEndpoints was unable to find any endpoint declarations!'
    })
    .SwaggerDocument(o =>
        {
            o.EnableJWTBearerAuth = false;
            o.DocumentSettings = s =>
            {
                s.Title = "Users API";
                s.Version = "v1";
            };
        }
    );

var app = builder.Build();
app
    .UseMyDefaultExceptionHandler() //.UseDefaultExceptionHandler()
    .UseFastEndpoints(c =>
    {
        c.Errors.UseProblemDetails(); // Use ProblemDetails for error responses
    }) 
    .UseSwaggerGen();
app.Run();
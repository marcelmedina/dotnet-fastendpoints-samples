using FastEndpoints;
using FastEndpoints.Swagger;
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
    .UseFastEndpoints()
    .UseSwaggerGen();
app.Run();
using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsSamples.Extensions;
using System.Reflection;
using FastEndpoints.ClientGen.Kiota;
using Kiota.Builder;

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

if (app.Environment.IsDevelopment())
{
    app.MapApiClientEndpoint("/cs-client", c =>
        {
            c.SwaggerDocumentName = "v1"; //must match document name set above
            c.Language = GenerationLanguage.CSharp;
            c.ClientNamespaceName = "Api";
            c.ClientClassName = "UsersClient";
        },
        o => //endpoint customization settings
        {
            o.CacheOutput(p => p.Expire(TimeSpan.FromDays(365))); //cache the zip
            // o.ExcludeFromDescription(); //hides this endpoint from swagger docs
        });
}

app.Run();
using System.Reflection;
using FastEndpoints;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints(o =>
{
    o.Assemblies = [Assembly.GetExecutingAssembly()]; // To avoid: System.InvalidOperationException: 'FastEndpoints was unable to find any endpoint declarations!'
});

var app = builder.Build();
app.UseFastEndpoints();
app.Run();
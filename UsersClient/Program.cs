using Api;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

// Set your API base URL here
var baseUrl = "https://localhost:7211/";

// Use the AnonymousAuthenticationProvider for anonymous/public APIs
var authProvider = new AnonymousAuthenticationProvider();
IRequestAdapter adapter = new HttpClientRequestAdapter(authProvider);

// Create the UsersClient
var client = new UsersClient(adapter);

// Use WithUrl to set the full endpoint for the user request
var userId = "0";
var userRequest = client.Api.User[userId].WithUrl($"{baseUrl}api/user/{userId}");
try
{
	var user = await userRequest.GetAsync();
	if (user != null)
	{
		Console.WriteLine($"Full Name: {user.FullName}");
		Console.WriteLine($"Is Over 18: {user.IsOver18}");
	}
	else
	{
		Console.WriteLine("User not found or response was null.");
	}
}
catch (Api.Models.FastEndpointsProblemDetails ex)
{
	Console.WriteLine("API error:");
	Console.WriteLine($"  Title: {ex.Title}");
	Console.WriteLine($"  Detail: {ex.Detail}");
	Console.WriteLine($"  Status: {ex.Status}");
	Console.WriteLine($"  Type: {ex.Type}");
	Console.WriteLine($"  Instance: {ex.Instance}");
	Console.WriteLine($"  TraceId: {ex.TraceId}");
	if (ex.Errors != null && ex.Errors.Count > 0)
	{
		Console.WriteLine("  Errors:");
		foreach (var err in ex.Errors)
		{
			Console.WriteLine($"    - Code: {err.Code}, Name: {err.Name}, Reason: {err.Reason}, Severity: {err.Severity}");
		}
	}
}
catch (Exception ex)
{
	Console.WriteLine($"Unexpected error: {ex.Message}");
}

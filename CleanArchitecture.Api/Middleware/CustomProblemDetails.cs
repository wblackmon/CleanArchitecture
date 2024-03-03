namespace CleanArchitecture.Api.Middleware;

public class CustomProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public IDictionary<string, string> ValidationErrors { get; set; } = new Dictionary<string, string>();
}

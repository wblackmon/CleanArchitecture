using CleanArchitecture.UI;
using CleanArchitecture.UI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
string baseAddress = builder.Configuration.GetSection("BaseAddress").Value ?? string.Empty;

builder.Services.AddScoped<IClient, Client>(builder => new Client(builder.GetRequiredService<IHttpClientFactory>().CreateClient(baseAddress)));

await builder.Build().RunAsync();

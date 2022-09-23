using Dictionary_Blazor.Web;
using Dictionary_Blazor.Web.Services;
using Dictionary_Blazor.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7008") });
builder.Services.AddScoped<IDictionaryService, DictionaryService>();

await builder.Build().RunAsync();

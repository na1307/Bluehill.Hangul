using Bluehill.Blazor;
using Bluehill.Hangul.Pages;
using HighlightBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddLocalization();

builder.Services.AddHighlight();

var host = await builder.BuildAndSetCultureAsync("ko-KR");

await host.RunAsync();

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
internal static partial class Program;

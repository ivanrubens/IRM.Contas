using IRM.Contas.Blazor.Wasm;
using IRM.Contas.Blazor.Wasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44330") });

//builder.Services.AddHttpClient("ContasAPI", (sp, cl) =>
//{
//    cl.BaseAddress = new Uri("https://localhost:44330/");
//});

//builder.Services.AddScoped(
//    sp => sp.GetService<IHttpClientFactory>().CreateClient("ContasAPI"));

builder.Services.AddScoped<IPeriodoService, PeriodoService>();
builder.Services.AddScoped<ILancamentoService, LancamentoService>();

builder.Services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

await builder.Build().RunAsync();

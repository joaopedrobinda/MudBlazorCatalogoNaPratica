using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudBlazorCatalogoNaPratica.Client.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient 
    { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<TokenAuthenticationProvider>();

builder.Services.AddScoped<IAuthorizeService>(
    provider => provider.GetRequiredService<TokenAuthenticationProvider>());

builder.Services.AddScoped<AuthenticationStateProvider>(
    provider => provider.GetRequiredService<TokenAuthenticationProvider>());

await builder.Build().RunAsync();

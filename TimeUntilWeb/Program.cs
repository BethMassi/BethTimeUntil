using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Root;
using Root.Interfaces;
using TimeUntilWeb.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Use Blazored OSS library for browser-local storage
builder.Services.AddBlazoredLocalStorageAsSingleton();

// Add device specific services used by RCL (Root)
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddSingleton<ILocalStorage, LocalStorage>();

await builder.Build().RunAsync();

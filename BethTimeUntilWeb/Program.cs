using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Root;
using Root.Interfaces;
using BethTimeUntilWeb.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredLocalStorageAsSingleton();

// Add device specific services used by RCL (Root)
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddSingleton<ILocalStorage, LocalStorage>();

//Needed for JS Interop to Web local storage
//builder.Services.AddScoped<Root.Services.LocalStorageAccessor>();

await builder.Build().RunAsync();

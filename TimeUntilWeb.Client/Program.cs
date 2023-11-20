using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Root;
using Root.Interfaces;
using Blazored.LocalStorage;
using TimeUntilWeb.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Use Blazored OSS library for browser-local storage
builder.Services.AddBlazoredLocalStorageAsSingleton();

// Add device specific services used by RCL (Root)
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddSingleton<ILocalStorage, LocalStorage>();
builder.Services.AddSingleton<IPhotoTaker, PhotoTaker>();

await builder.Build().RunAsync();

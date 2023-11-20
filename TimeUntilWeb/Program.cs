using TimeUntilWeb.Components;
using Root.Interfaces;
using Blazored.LocalStorage;
using TimeUntilWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//Use Blazored OSS library for browser-local storage
builder.Services.AddBlazoredLocalStorage();

// Add device specific services used by RCL (Root)
builder.Services.AddScoped<IFormFactor, FormFactor>();
builder.Services.AddScoped<ILocalStorage, LocalStorage>();
builder.Services.AddScoped<IPhotoTaker, PhotoTaker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TimeUntilWeb.Client._Imports).Assembly)
    .AddAdditionalAssemblies(typeof(Root._Imports).Assembly);

app.Run();

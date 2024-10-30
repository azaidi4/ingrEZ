using MudBlazor.Services;
using ingrEZ.Components;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var geminiApiUrl = builder.Configuration["Gemini:ApiUrl"] ??
    throw new Exception("GeminiApiUrl is not set");

var recipeConnectionString = builder.Configuration.GetConnectionString("IngrEZDataContext") ??
    throw new InvalidOperationException("Connection string 'IngrEZDataContext' not found.");

builder.Services.AddHttpClient("Gemini", httpClient => httpClient.BaseAddress = new Uri(geminiApiUrl))
.AddStandardResilienceHandler(options =>
{
  options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(50);
  options.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(120);
  options.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(100);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

// Set up custom content types - associating file extension to MIME type
var provider = new FileExtensionContentTypeProvider();
// Add new mappings
provider.Mappings[".avif"] = "image/avif";

app.UseStaticFiles(new StaticFileOptions
{
  ContentTypeProvider = provider
});

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

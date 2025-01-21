global using Microsoft.AspNetCore.Components.Forms;
global using Microsoft.EntityFrameworkCore;
global using UDI_Januar2025.Models.Dto;
global using UDI_Januar2025.Components;
global using UDI_Januar2025.Data;
global using UDI_Januar2025.Models;
global using UDI_Januar2025.Services.FilService;
global using UDI_Januar2025.Services.DataLesService;
using UDI_Januar2025;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterAppServices();

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

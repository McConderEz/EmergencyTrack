using EmergencyTrack;
using EmergencyTrack.Infrastructure.Mssql;
using EmergencyTrack.Api.Components;
using EmergencyTrack.Application;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();

builder.Services.AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddQuickGridEntityFrameworkAdapter();

builder.Services.AddFluentValidationAutoValidation();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

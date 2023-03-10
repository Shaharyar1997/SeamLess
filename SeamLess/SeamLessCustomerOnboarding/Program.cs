using MetaMask.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Blazored.Modal;
using SeamLessCustomerOnboarding.Data;
using SeamLessCustomerOnboarding.Models;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMetaMaskBlazor();
builder.Services.AddBlazoredModal();
builder.Services.AddSingleton<MailService>();
builder.Services.AddSingleton<MetaMaskStateContainer>();
builder.Services.AddTransient<SeamLessCustomerOnboarding.Models.MetaMaskService>();
builder.Services.AddSingleton<StateContainerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

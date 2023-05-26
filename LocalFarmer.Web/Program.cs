global using LocalFarmer.Domain.Models;
global using LocalFarmer.Web.Services;
global using LocalFarmer.Web.ViewModels;
global using LocalFarmer.Domain.ViewModels.DTOs;
global using System.Net.Http.Json;
global using AutoMapper;
using LocalFarmer.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IFarmhouseService, FarmhouseService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();

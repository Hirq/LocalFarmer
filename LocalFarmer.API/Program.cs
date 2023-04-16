using LocalFarmer.API.Utilities;
using LocalFarmer.Data.Context;
using LocalFarmer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
        .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.OperationFilter<ReApplyOptionalRouteParameterOperationFilter>();
    s.EnableAnnotations();
});
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddDbContext<LocalfarmerDbContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(
        builder.Configuration["ConnectionStrings:LocalFarmerDBConnectionString"]));

builder.Services.AddScoped<IFarmhouseRepository, FarmhouseRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

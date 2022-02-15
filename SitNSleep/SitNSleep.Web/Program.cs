using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SitNSleep.Data.Context;
using SitNSleep.Services.Interfaces;
using SitNSleep.Services.Services;
using SitNSleep.Web.Mapper;
using SitNSleep.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var dbConnectionString = builder.Configuration.GetSection("ConnectionStrings:UpSystem").Value;

builder.Services.AddDbContext<UpSystemDbContext>(options =>
{
    options.UseSqlServer(dbConnectionString);
});

builder.Services.AddTransient<ISalesPersonService, SalesPersonService>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new DomainProfile());
});
IMapper autoMapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(autoMapper);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SalesPerson}/{action=Index}");

app.UseSwaggerUI();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapRazorPages();

app.Run();

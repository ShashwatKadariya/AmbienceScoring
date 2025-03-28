using AmbienceScoring.Data;
using AmbienceScoring.Repository;
using AmbienceScoring.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.AddJsonFile("appsettings.Development.Local.json", optional: false, reloadOnChange: true);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Loaded Connection String: {connectionString}");

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(connectionString));



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IParameterRepository, ParameterRepository>();
builder.Services.AddScoped<IAssesmentRepository, AssesmentRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
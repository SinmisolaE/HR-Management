using HRService.Core.Interfaces.RepositoryInterface;
using HRService.Core.Interfaces.RepositroyInterface;
using HRService.Infrastructure.Data;
using HRService.Infrastructure.Interfaces;
using HRService.Infrastructure.Repository;
using HRService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Hour)
    .CreateLogger();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Logging.AddSerilog();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeLeaveRepository, EmployeeLeaveRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();


builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IDepartmentService, JobService>();
builder.Services.AddScoped<ILeaveService, LeaveService>();
builder.Services.AddScoped<IEmployeeLeaveService, LeaveService>();

builder.Services.AddDbContext<HRDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HRDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

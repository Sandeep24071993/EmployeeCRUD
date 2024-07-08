using EmployeeCRUD.Data;
using EmployeeCRUD.DepartmentRepository.Interface;
using EmployeeCRUD.DepartmentRepository.Service;
using EmployeeCRUD.DepartmentService;
using EmployeeCRUD.DesignationRepository.Interface;
using EmployeeCRUD.DesignationRepository.Service;
using EmployeeCRUD.DesignationService;
using EmployeeCRUD.EmployeeRepository.Interface;
using EmployeeCRUD.EmployeeRepository.Service;
using EmployeeCRUD.EmployeeService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmployeeDbContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));
builder.Services.AddScoped<IDesignation, DesignationRepository>();
builder.Services.AddScoped<IDesignationService , DesignationService>();
builder.Services.AddScoped<IDepartment, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployee, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

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

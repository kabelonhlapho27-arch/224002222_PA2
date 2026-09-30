// Group leader name : Kabelo Nhlapo
// Group Student nrs : 220048471; <student nr>; <student nr>
// Assignment nr     : SOD226C Practical Assessment 2 · 2026
// Purpose           : The purpose of this file is to serve as the application entry point,
//                     registering the required services (MVC and the BoardContext database
//                     context) and configuring the HTTP request pipeline and routing.

using BoardAppDB.Data;
using Microsoft.EntityFrameworkCore;

// Create the web application builder
var builder = WebApplication.CreateBuilder(args);

// Add MVC controllers and views to the services container
builder.Services.AddControllersWithViews();

// Register BoardContext with the SQLite provider and the DefaultConnection connection string
builder.Services.AddDbContext<BoardContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    // Use the error page and HSTS outside the development environment
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} // end if

// Redirect HTTP to HTTPS and serve static files from wwwroot
app.UseHttpsRedirection();
app.UseStaticFiles();

// Enable routing and authorization
app.UseRouting();
app.UseAuthorization();

// Map the default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application
app.Run();
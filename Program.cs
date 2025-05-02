using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderManagement.RazorWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Fix: Use builder.Configuration instead of Configuration
var sqlConnectionBuilder = new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("DefaultConnection"))
{
    TrustServerCertificate = true
};

// Fix: Remove incorrect CoreEventId reference
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(sqlConnectionBuilder.ConnectionString));

builder.Services.AddRazorPages();

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
app.UseSession(); // Add this line
app.UseAuthorization();
app.MapRazorPages();

app.Run();
using Microsoft.EntityFrameworkCore;
using OrderManagement.RazorWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();

// Add session support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add custom authentication
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.Cookie.Name = "OrderManagementCookie";
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied";
    });

// Configure authorized pages
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizePage("/Reports/Index");
        options.Conventions.AuthorizePage("/Reports/BestItems");
        options.Conventions.AuthorizePage("/Reports/ItemsByAgent");
        options.Conventions.AuthorizePage("/Reports/OrderDetails");
        options.Conventions.AuthorizePage("/Reports/AgentPerformance");
        options.Conventions.AuthorizePage("/Reports/Print");
        // Add other pages that require authorization
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add these in this exact order
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
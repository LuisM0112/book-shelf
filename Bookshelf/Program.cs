using Bookshelf.Data;
using Bookshelf.Models;
using Bookshelf.Services.Implementations;
using Bookshelf.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Entity Framework Core
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
  ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Identity
builder.Services
  .AddIdentity<User, IdentityRole>()
  .AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders();

// Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ILibraryService, LibraryService>();

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages().WithStaticAssets();

using (IServiceScope scope = app.Services.CreateScope())
{
  IServiceProvider services = scope.ServiceProvider;

  await DbInitializer.InitializeAsync(services);
}

app.Run();

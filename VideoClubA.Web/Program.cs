using Autofac.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Compact;
using System.Configuration;
using VideoClubA.Authentication.Data;
using VideoClubA.Authentication.Data.Account;
using VideoClubA.Common.Services;
using VideoClubA.Core.Interfaces;
using VideoClubA.Infrastucture.Data;
using VideoClubA.Web.Profiler;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .Enrich.WithThreadId()
    .Enrich.WithProcessId() 
    .Enrich.WithEnvironmentName()
    .WriteTo.Console(new CompactJsonFormatter())
    .WriteTo.File(new CompactJsonFormatter(),"./Log/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Logger.Information("Logging is working");

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog();

//Automapper
builder.Services.AddAutoMapper(typeof(MovieWithAvailabilityProfiler));

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("VideoClubDbContextConnection") ??
        throw new InvalidOperationException("Connection string 'VideoClubDbContextConnection' not found.");

builder.Services.AddDbContext<VideoClubDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieCopyService, MovieCopyService>();
builder.Services.AddScoped<ICustomerSevice, CustomerService>();
builder.Services.AddScoped<IMovieRentService,  MovieRentService>();

builder.Services.AddSingleton<Dictionary<string, int>>(new Dictionary<string, int>());

//Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller}/{action}"
);
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
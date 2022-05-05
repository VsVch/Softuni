using ASP.netCoreTreningApp.Data;
using ASP.netCoreTreningApp.Filters;
using ASP.netCoreTreningApp.ModelBinders;
using ASP.netCoreTreningApp.RouteConstraint;
using ASP.netCoreTreningApp.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient<IShortStringService, ShortStringService>();
builder.Services.AddTransient<IInstanceCounter, InstanceCounter>();

builder.Services.AddRouting(option =>
{
    option.ConstraintMap.Add("cyrillic", typeof(CyrillicRouteConstraint));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;   
})
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews(configure => 
{
    configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
    configure.Filters.Add(new AddHeaderActionFilter());
    configure.Filters.Add(new MyAlthFilter());
    configure.Filters.Add(new MyExeptionFilter());
    configure.Filters.Add(new MyResultFilterAtribute());
    configure.Filters.Add(new MyResurceFilter());
    configure.ModelBinderProviders.Insert(0, new ExtractYearModelBinderProvider());
}).AddXmlSerializerFormatters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseStatusCodePagesWithRedirects("Home/StatusCodeError?statusCode={0}");
    app.UseMigrationsEndPoint();
    
}
else
{

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

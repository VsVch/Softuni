using ASP.netCoreTreningApp.Data;
using ASP.netCoreTreningApp.Filters;
using ASP.netCoreTreningApp.ModelBinders;
using ASP.netCoreTreningApp.RouteConstraint;
using ASP.netCoreTreningApp.Service;
using ASP.netCoreTreningApp.Settings;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettingsSection);

builder.Services.AddMemoryCache();

builder.Services.AddDistributedSqlServerCache(option =>
{
    option.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    option.SchemaName = "dbo";
    option.TableName = "CacheRecords";
});

var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

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

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Jwt token default authentication schema
//builder.Services.AddAuthentication(
//    options =>
//    {
//        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    });

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

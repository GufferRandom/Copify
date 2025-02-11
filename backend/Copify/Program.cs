using Copify.AppliocatioDbContext;
using Copify.Interfaces;
using Copify.Models;
using Copify.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var dbhost = Environment.GetEnvironmentVariable("DB_HOST") ?? "DESKTOP\\SQLEXPRESS";
var dbname = Environment.GetEnvironmentVariable("DBNAME") ?? "Rp";
var pwd = Environment.GetEnvironmentVariable("DB_SA_PASS") ?? "nagazi2@";
builder.Configuration["ConnectionStrings:DefaultConnection"] = $"Data Source={dbhost};Initial Catalog={dbname};User Id=sa;Password={pwd};TrustServerCertificate=True";
builder.Services.AddDbContext<AppDataContext>(

    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase=true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength=8;
}).AddEntityFrameworkStores<AppDataContext>();
builder.Services.AddAuthentication(options=> {
    options.DefaultAuthenticateScheme=
    options.DefaultChallengeScheme=
    options.DefaultForbidScheme =
    options.DefaultScheme = 
    options.DefaultSignInScheme=
    options.DefaultSignOutScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))
    };
});
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITokenService,TokenService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDataContext>();
    db.Database.Migrate();
}
app.Run();
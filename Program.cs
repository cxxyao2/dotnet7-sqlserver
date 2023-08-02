global using dotnet7_sqlserver.Models;
global using dotnet7_sqlserver.Services.CharacterService;
global using dotnet7_sqlserver.Dtos.Character;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using dotnet7_sqlserver.Services.WeaponService;
global using dotnet7_sqlserver.Services.FightService;
using dotnet7_sqlserver.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using dotnet7_sqlserver.Services.EmailService;

var builder = WebApplication.CreateBuilder(args);
// Check whether the environment variable exists.
var value = Environment.GetEnvironmentVariable("Test1");
if(value != null)
{
  Console.WriteLine($"Test1: {value}");
}
else
{
  Console.WriteLine("Test1 does not exist.");
}

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddResponseCaching();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.AddSecurityDefinition(
"oauth2", new OpenApiSecurityScheme
{
  Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer  {token}\"",
  In = ParameterLocation.Header,
  Name = "Authorization",
  Type = SecuritySchemeType.ApiKey
}
  );

  c.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IWeaponService, WeaponService>();
builder.Services.AddScoped<IFightService, FightService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
      ValidateIssuer = false,
      ValidateAudience = false
    };
  });


builder.Services.AddAuthorization(options =>
    {
      options.AddPolicy("AdminOnly", policy =>
      {
        policy.RequireClaim("UserRole", "Admin");
      });
    });

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseCors();
app.UseResponseCaching();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Use(async (context, next) =>
{
  Console.WriteLine("Before");
  await next.Invoke();
  Console.WriteLine("After");

});
app.Run();

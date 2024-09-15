

using Business.IServices;
using Business.Services;
using DataAccess;
using DataAccess.IRepository;
using DataAccess.Repositories;
using Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // JWT Authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
       {
           {
               new OpenApiSecurityScheme
               {
                   Reference = new OpenApiReference
                   {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                   },
                   Scheme = "oauth2",
                   Name = "Bearer",
                   In = ParameterLocation.Header,
               },
               new List<string>()
           }
       });
});

// JWT Ayarlarý
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateLifetime = true
    };

    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var userId = context.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId != null)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId));
                }
            }
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireAuthorRole", policy => policy.RequireRole("Author"));
    options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
});

// Add services to the container.
builder.Services.AddDbContext<BlogDbContext>(options =>

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddIdentity<AppUser, IdentityRole<int>>()
    .AddEntityFrameworkStores<BlogDbContext>()
    .AddRoleManager<RoleManager<IdentityRole<int>>>();

// DI Service
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddAuthorization();
builder.Services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

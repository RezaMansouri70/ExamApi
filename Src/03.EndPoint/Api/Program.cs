using ApplicationServices.Services.UserExam;
using DataLayer.SqlServer.Common;
using DataLayer.SqlServer.Repositories;
using DomainClass.UserExam;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApplicationServices.Services.UserService;
using FluentValidation.AspNetCore;
using FluentValidation;
using ApplicationServices.Models.UserExam;
using ApplicationServices.Models.UserModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddTransient<IValidator<AddUserExamDto>, AddUserExamDtoValidation>();
builder.Services.AddTransient<IValidator<AddUserDto>, AddUserDtoValidation>();
builder.Services.AddTransient<IValidator<LoginUserDto>, LoginUserDtoValidation>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var cnnString = builder.Configuration.GetConnectionString("AppCnn");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(cnnString));



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });


builder.Services.AddScoped<IUserExamService, UserExamService>();
builder.Services.AddScoped<IUserExamRepository, UserExamRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
app.MapControllers();

app.Run();

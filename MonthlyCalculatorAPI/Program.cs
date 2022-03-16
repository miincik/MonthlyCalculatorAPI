
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MonthlyCalculatorAPI.Contexts;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Concrete;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Concrete;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Security.JWT;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblyContaining<Program>();
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MonthlyCalculatorDbContext>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenHelper, JwtHelper>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IExpenceRepository, ExpenceRepository>();
builder.Services.AddScoped<IExpenceTypeRepository, ExpenceTypeRepository>();
builder.Services.AddScoped<IExpenceHistoryRepository, ExpenceHistoryRepository>();
builder.Services.AddScoped<IExpenceService, ExpenceService>();
builder.Services.AddScoped<IExpenceTypeService, ExpenceTypeService>();
builder.Services.AddScoped<IExpenceHistoryService, ExpenceHistoryService>();

builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
builder.Services.AddScoped<ISalaryTypeRepository, SalaryTypeRepository>();
builder.Services.AddScoped<ISalaryHistoryRepository, SalaryHistoryRepository>();
builder.Services.AddScoped<ISalaryService, SalaryService>();
builder.Services.AddScoped<ISalaryTypeService, SalaryTypeService>();
builder.Services.AddScoped<ISalaryHistoryService, SalaryHistoryService>();
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

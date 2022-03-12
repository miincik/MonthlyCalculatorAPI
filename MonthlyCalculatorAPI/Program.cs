using Castle.DynamicProxy;
using FluentValidation.AspNetCore;
using MonthlyCalculatorAPI.Contexts;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Concrete;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;
using MonthlyCalculatorAPI.Services.Concrete;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Intercaptors;
using MonthlyCalculatorAPI.Utilities.Security;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblyContaining<Program>();
});

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MonthlyCalculatorDbContext>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IGenderService, GenderService>();

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
app.UseMiddleware<JwtMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

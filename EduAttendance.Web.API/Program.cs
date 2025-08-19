using EduAttendance.Web.API.Context;
using EduAttendance.Web.API.Dtos;
using EduAttendance.Web.API.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer("Server=BARANPC\\SQLEXPRESS;Database=TanerHocaEduAttendance;integrated security=True; TrustServerCertificate=True;");
});


builder.Services.AddControllers();
builder.Services.AddOpenApi();
//builder.Services.AddValidatorsFromAssemblyContaining<CreateStudenValidator>();
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();


app.Run();

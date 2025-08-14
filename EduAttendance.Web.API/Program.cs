using EduAttendance.Web.API.Context;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer("Server=BARANPC\\SQLEXPRESS;Database=TanerHocaEduAttendance;integrated security=True; TrustServerCertificate=True;");
});


builder.Services.AddControllers();
builder.Services.AddOpenApi();
var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();


app.Run();

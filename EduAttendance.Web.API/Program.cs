using EduAttendance.Web.API.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer("Server=BARANPC\\SQLEXPRESS;Database=TanerHocaEduAttendance;integrated security=True; TrustServerCertificate=True;");
});


builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();


app.Run();

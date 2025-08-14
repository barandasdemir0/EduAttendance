using EduAttendance.Web.API.Context;
using EduAttendance.Web.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduAttendance.Web.API.Controller
{
   
    [ApiController]
    [Route("[controller]")]
    public sealed class StudentsController : ControllerBase
    {
        ApplicationDbContext _dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> students = _dbContext.Students.ToList();
            return Ok(students);

            //deneme

        }
    }
}

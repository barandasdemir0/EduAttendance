using EduAttendance.Web.API.Context;
using EduAttendance.Web.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduAttendance.Web.API.Controller
{
   
    [ApiController]
    [Route("[controller]")]
    public sealed class StudentsController(ApplicationDbContext dbContext) : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
           
            List<Student> students = await dbContext.Students.ToListAsync(cancellationToken);
            return Ok(students);

           

        }
    }
}

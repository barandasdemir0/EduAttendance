using EduAttendance.Web.API.Context;
using EduAttendance.Web.API.Dtos;
using EduAttendance.Web.API.Models;
using EduAttendance.Web.API.Validators;
using FluentValidation.Results;
using Mapster;
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

        Result res = default!;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {

            //string name = "Baran Daşdemir";
            //name.ToUpper();


            List<Student> students = await dbContext.Students.ToListAsync(cancellationToken);
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudenDto request, CancellationToken cancellationToken)
        {



            //mapster kurmadım böyle olur 
            //Student student = new()
            //{
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    Email = request.Email,
            //    IdentityNumber = request.IdentityNumber,
            //    PhoneNumber = request.PhoneNumber,
            //};

            CreateStudenValidator validations = new();
            ValidationResult validationResult = validations.Validate(request);
            if (validationResult.IsValid == false)
            {
                res = Result.Fail(validationResult.Errors.Select(s => s.ErrorMessage).ToList());
                return BadRequest(res);
            }


            var isIdentityNumberExists = await dbContext.Students.AnyAsync(p => p.IdentityNumber == request.IdentityNumber, cancellationToken);

            if (isIdentityNumberExists == true)
            {
                res = Result.Fail ("Öğrenci kaydı başarıyla tamamlandı");
                return BadRequest(res);
            }

            //fluent kullanmazsak böle saçma kullanırız
            //if (string.IsNullOrEmpty(request.FirstName) || request.FirstName.Length<3)
            //{
            //    return BadRequest("boş olmamalı ve 3 karakterden az olmamalı");
            //}

            //mapster kurarsam böyle olur 
            Student student = request.Adapt<Student>();
            dbContext.Add(student);
            await dbContext.SaveChangesAsync(cancellationToken);
            //await dbContext.SaveChangesAsync(cancellationToken);
            //return Ok(new { message = "Öğrenci kaydı başarıyla tamamlandı" });





            res =  Result.Succeed("Öğrenci kaydı başarıyla tamamlandı");
            return Ok(res);


        }








    }
}

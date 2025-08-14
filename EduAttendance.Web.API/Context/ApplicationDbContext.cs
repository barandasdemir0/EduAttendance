using EduAttendance.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EduAttendance.Web.API.Context
{
    public sealed class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}

namespace EduAttendance.Web.API.Models
{
    public sealed class Student //studentın kendisi inheritance yapmıyor çünkü sadece veri taşıyor böylelikle başka sınıf tarafından değiştirilmesi engellenmiş oluyor
    {
        public Student()
        {
            Id = Guid.CreateVersion7(); 
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string IdentityNumber { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}

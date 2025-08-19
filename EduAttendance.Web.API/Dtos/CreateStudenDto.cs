namespace EduAttendance.Web.API.Dtos
{
    public sealed class CreateStudenDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string IdentityNumber { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}

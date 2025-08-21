namespace EduAttendance.Web.API.Dtos
{
    public sealed record UpdateStudenDto(
        Guid Id,
        string FirstName,
        string LastName,
        string IdentityNumber,
        string PhoneNumber,
        string Email);
  
}

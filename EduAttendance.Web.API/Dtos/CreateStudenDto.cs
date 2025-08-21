namespace EduAttendance.Web.API.Dtos
{
    public sealed  record CreateStudenDto(
        string FirstName, 
        string LastName,
        string IdentityNumber, 
        string PhoneNumber, 
        string Email);
   
}

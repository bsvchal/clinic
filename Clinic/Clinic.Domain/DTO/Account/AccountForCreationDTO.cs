namespace Clinic.Domain.DTO.Account;

public class AccountForCreationDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string? PathToPhoto { get; set; }
}

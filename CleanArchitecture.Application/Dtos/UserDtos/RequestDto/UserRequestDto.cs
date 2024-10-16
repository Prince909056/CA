using CleanArchitecture.Application.Dtos.CommanDtos;
using CleanArchitecture.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dtos.UserDtos.RequestDto;
public class UserRequestDto : PageCountDto, IValidatableObject
{
    public int Id { get; set; }
    [Required(ErrorMessage = $"{nameof(FirstName)} is required.")]
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    [Required(ErrorMessage = $"{nameof(Gender)} is required.")]
    public required GenderEnum Gender { get; set; }
    [Required(ErrorMessage = $"{nameof(Age)} is required.")]
    public required int Age { get; set; }
    [Required(ErrorMessage = $"Phone number is required.")]
    [Phone(ErrorMessage = $"Phone number is not valid.")]
    public required string Phone { get; set; }
    [Required(ErrorMessage = $"{nameof(Email)} is required.")]
    [EmailAddress(ErrorMessage = $"Please enter a valid email address (e.g., name@example.com)")]
    public required string Email { get; set; }
    public string Password { get; set; }
    [Required(ErrorMessage = $"{nameof(UserType)} is required.")]
    public required string UserType { get; set; }
    public string OfficeStaffType { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Age >= 18)
            yield return new ValidationResult("Age must be at least 18.");

        if (Gender.ToString() == GenderEnum.Male.ToString() &&
            Gender.ToString() == GenderEnum.Female.ToString() &&
            Gender.ToString() == GenderEnum.Other.ToString())
            yield return new ValidationResult("Please select Gender from the given one.");

        if (UserType.ToString() == UserTypeEnum.Admin.ToString() &&
            UserType.ToString() == UserTypeEnum.OfficeStaff.ToString() &&
            UserType.ToString() == UserTypeEnum.Teacher.ToString() &&
            UserType.ToString() == UserTypeEnum.Student.ToString())
            yield return new ValidationResult("Please select UserType from the given one.");

        if (UserType.ToString() == UserTypeEnum.OfficeStaff.ToString() &&
            (OfficeStaffType == null ||
            OfficeStaffType == string.Empty))
            yield return new ValidationResult($"{nameof(OfficeStaffType)} is required for user type OfficeStaff.");

        if (UserType.ToString() == UserTypeEnum.OfficeStaff.ToString() &&
            OfficeStaffType.ToString() == OfficeStaffTypeEnum.Accountant.ToString() &&
            OfficeStaffType.ToString() == OfficeStaffTypeEnum.HR.ToString() &&
            OfficeStaffType.ToString() == OfficeStaffTypeEnum.Receptionist.ToString() &&
            OfficeStaffType.ToString() == OfficeStaffTypeEnum.Cashier.ToString())
            yield return new ValidationResult("Please select OfficeStaff type from the given one.");
    }
}

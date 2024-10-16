using CleanArchitecture.Application.Dtos.CommanDtos;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dtos.UserDtos.ResponseDto;
public class UserResponseDto : BaseDto
{
    [Required]
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    [Required]
    public required string Gender { get; set; }
    [Required]
    public required int Age { get; set; }
    [Required]
    public required string Number { get; set; }
    [Required]
    public required string Email { get; set; }
    public string Password { get; set; }
    [Required]
    public required string UserType { get; set; }
    public string OfficeStaffType { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dtos.EmailConfigDtos.RequestDto;
public class EmailConfigRequestDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = $"{nameof(FromMail)} is required.")]
    [EmailAddress(ErrorMessage = $"Please enter a valid {nameof(FromMail)} address (e.g., name@example.com)")]
    public required string FromMail { get; set; }
    [Required(ErrorMessage = $"{nameof(SmtpServer)} is required.")]
    public required string SmtpServer { get; set; }
    [Required(ErrorMessage = $"{nameof(SmtpPort)} is required.")]
    public required int SmtpPort { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool EnableSsl { get; set; }
}

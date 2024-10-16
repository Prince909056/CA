using CleanArchitecture.Application.Dtos.CommanDtos;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dtos.EmailConfigDtos.ResponseDto;
public class EmailConfigResponseDto : BaseDto
{
    [Required]
    public required string FromMail { get; set; }
    [Required]
    public required string SmtpServer { get; set; }
    [Required]
    public required int SmtpPort { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool EnableSsl { get; set; }
}

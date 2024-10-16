namespace CleanArchitecture.Domain.Entities.EmailConfigEntities;
[Table(nameof(EmailConfig))]
public class EmailConfig : BaseEntity
{
    [Required]
    public required string FromMail { get; set; }  // Sender's email address
    [Required]
    public required string SmtpServer { get; set; }  // SMTP server address (e.g., smtp.gmail.com)
    [Required]
    public required int SmtpPort { get; set; }  // Port number for the SMTP server (typically 587 for TLS, 465 for SSL)
    public string Username { get; set; }  // Username for SMTP authentication
    public string Password { get; set; }  // Password for SMTP authentication
    public bool EnableSsl { get; set; }
}

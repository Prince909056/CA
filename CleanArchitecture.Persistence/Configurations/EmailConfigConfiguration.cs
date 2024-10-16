using CleanArchitecture.Domain.Entities.EmailConfigEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations;
public class EmailConfigConfiguration : IEntityTypeConfiguration<EmailConfig>
{
    public void Configure(EntityTypeBuilder<EmailConfig> builder)
    {
        ConfigureKeys(builder);
        SeedInitialData(builder);
    }

    private void ConfigureKeys(EntityTypeBuilder<EmailConfig> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd(); // Ensure ID is auto-generated for other users
    }

    private void SeedInitialData(EntityTypeBuilder<EmailConfig> builder)
    {
        builder.HasData(new EmailConfig()
        {
            Id = -1,
            FromMail = "prince.chand@anviam.com",
            SmtpServer = "smtp.gmail.com",
            SmtpPort = 587,
            Username = "Admin",
            Password = "ADX6 7GFR 9JHY",
            EnableSsl = false,
            CreatedDate = DateTime.UtcNow,
        });
    }
}

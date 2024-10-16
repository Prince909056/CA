using CleanArchitecture.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureKeys(builder);
        SeedInitialData(builder);
    }

    private void ConfigureKeys(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd(); // Ensure ID is auto-generated for other users
    }

    private void SeedInitialData(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User()
        {
            Id = -1,
            FirstName = "Prince",
            LastName = "Chand",
            Gender = GenderEnum.Male.ToString(),
            Age = 23,
            Phone = "9876543210",
            Email = "prince@gmail.com",
            Password = "123",
            UserType = UserTypeEnum.Admin.ToString(),
            OfficeStaffType = string.Empty,
            CreatedDate = DateTime.Now,
        });
    }
}

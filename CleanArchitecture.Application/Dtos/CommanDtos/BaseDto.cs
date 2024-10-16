namespace CleanArchitecture.Application.Dtos.CommanDtos;
public class BaseDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public bool IsUpdated { get; set; } = false;
    public DateTime UpdatedDate { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}

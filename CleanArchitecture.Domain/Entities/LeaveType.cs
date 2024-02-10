using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class LeaveType : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}

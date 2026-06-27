namespace FinPilot.Domain.Common;

/// <summary>
/// Extends BaseEntity with audit fields for tracking
/// who created/modified entities and when.
/// </summary>
public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}

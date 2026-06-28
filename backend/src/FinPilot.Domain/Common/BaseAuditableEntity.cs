namespace FinPilot.Domain.Common;

/// <summary>
/// Extends BaseEntity with audit fields for tracking who created/modified entities,
/// soft-delete support, and an optimistic concurrency token.
/// Used by entities that require full audit trails (e.g., User).
/// </summary>
public abstract class BaseAuditableEntity : BaseEntity
{
    /// <summary>
    /// UTC timestamp of the last modification. Null if never modified.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Identifier of the user who created this entity.
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Identifier of the user who last modified this entity.
    /// </summary>
    public string? UpdatedBy { get; set; }

    // ── Soft Delete ──────────────────────────────────────────

    /// <summary>
    /// When true, this entity is logically deleted but retained for audit.
    /// A global query filter excludes soft-deleted rows by default.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// UTC timestamp when the entity was soft-deleted.
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// Identifier of the user who soft-deleted this entity.
    /// </summary>
    public string? DeletedBy { get; set; }

    // ── Concurrency ──────────────────────────────────────────

    /// <summary>
    /// Optimistic concurrency token.
    /// EF Core maps this to PostgreSQL's xmin system column.
    /// </summary>
    public uint RowVersion { get; set; }

    /// <summary>
    /// Marks this entity as soft-deleted.
    /// </summary>
    public void SoftDelete(string? deletedBy = null)
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
        DeletedBy = deletedBy;
    }

    /// <summary>
    /// Restores a soft-deleted entity.
    /// </summary>
    public void Restore()
    {
        IsDeleted = false;
        DeletedAt = null;
        DeletedBy = null;
    }
}

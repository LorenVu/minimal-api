using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clothes.Domain.Common;

namespace Clothes.Domain.Entities;

[Table("application_config")]
public class ApplicationConfig : EntityAuditBase<int>, IStatusTracking
{
    [Required]
    [Column("config_key", TypeName = "varchar(100)")]
    public required string ConfigKey { get; set; }
    
    [Required]
    [Column("config_value", TypeName = "text")]
    public required string ConfigValue { get; set; }
    
    [Required]
    [Column("config_value_type", TypeName = "varchar(50)")]
    public required string ConfigValueType { get; set; }
    
    [Column("reference_id")]
    public int ReferenceId { get; set; }
    
    [Column("reference_type", TypeName = "varchar(50)")]
    public string? ReferenceType { get; set; }
    
    [Column("description", TypeName = "varchar(255)")]
    public string? Description { get; set; }
    
    [Column("is_active", TypeName = "byte")]
    public int IsActive { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}
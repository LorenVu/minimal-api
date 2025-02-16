using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities;

[Table("Brands")]
public class Brand : EntityAuditBase<int>
{
    [Required]
    [Column("Name")]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Column("Code")]
    [MaxLength(100)]
    public string? Code { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}
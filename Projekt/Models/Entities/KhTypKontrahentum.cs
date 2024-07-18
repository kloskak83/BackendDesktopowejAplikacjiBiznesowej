using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("kh_TypKontrahenta")]
public partial class KhTypKontrahentum
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nazwa { get; set; } = null!;

    [InverseProperty("KhIdTypKontrahentaNavigation")]
    public virtual ICollection<KhKontrahent> KhKontrahents { get; set; } = new List<KhKontrahent>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("sl_GrupaKh")]
[Index("GrkNazwa", Name = "UQ__sl_Grupa__88FE66AE255A4FB5", IsUnique = true)]
public partial class SlGrupaKh
{
    [Key]
    [Column("grk_Id")]
    public int GrkId { get; set; }

    [Column("grk_Nazwa")]
    [StringLength(50)]
    [Unicode(false)]
    public string GrkNazwa { get; set; } = null!;

    [InverseProperty("KhIdGrupaNavigation")]
    public virtual ICollection<KhKontrahent> KhKontrahents { get; set; } = new List<KhKontrahent>();
}

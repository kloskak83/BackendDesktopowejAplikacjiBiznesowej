using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("sl_PolaWlasne")]
[Index("PwNazwaPola", Name = "UQ__sl_PolaW__801172E8F44337F2", IsUnique = true)]
public partial class SlPolaWlasne
{
    [Key]
    [Column("pw_Id")]
    public int PwId { get; set; }

    [Column("pw_NazwaPola")]
    [StringLength(50)]
    [Unicode(false)]
    public string PwNazwaPola { get; set; } = null!;

    [Column("pw_OpisPola")]
    [StringLength(255)]
    [Unicode(false)]
    public string? PwOpisPola { get; set; }

    [InverseProperty("PwtIdPoleWlasneNavigation")]
    public virtual ICollection<SlPolaWlasneTowarow> SlPolaWlasneTowarows { get; set; } = new List<SlPolaWlasneTowarow>();
}

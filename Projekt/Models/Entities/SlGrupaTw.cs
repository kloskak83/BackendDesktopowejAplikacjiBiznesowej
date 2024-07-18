using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("sl_GrupaTw")]
public partial class SlGrupaTw
{
    [Key]
    [Column("grt_Id")]
    public int GrtId { get; set; }

    [Column("grt_Nazwa")]
    [StringLength(100)]
    public string GrtNazwa { get; set; } = null!;

    [InverseProperty("TwIdGrupaNavigation")]
    public virtual ICollection<TwTowar> TwTowars { get; set; } = new List<TwTowar>();
}

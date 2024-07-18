using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("sl_Magazyn")]
public partial class SlMagazyn
{
    [Key]
    [Column("mag_Id")]
    public int MagId { get; set; }

    [Column("mag_Symbol")]
    [StringLength(50)]
    public string MagSymbol { get; set; } = null!;

    [Column("mag_Nazwa")]
    [StringLength(200)]
    public string MagNazwa { get; set; } = null!;

    [Column("mag_Opis")]
    [StringLength(255)]
    [Unicode(false)]
    public string? MagOpis { get; set; }

    [Column("mag_Glowny")]
    public bool? MagGlowny { get; set; }

    [InverseProperty("DokMag")]
    public virtual ICollection<DokDokument> DokDokuments { get; set; } = new List<DokDokument>();
}

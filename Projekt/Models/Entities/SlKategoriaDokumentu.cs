using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("sl_KategoriaDokumentu")]
public partial class SlKategoriaDokumentu
{
    [Key]
    [Column("kd_Id")]
    public int KdId { get; set; }

    [Column("kd_Nazwa")]
    [StringLength(100)]
    public string KdNazwa { get; set; } = null!;

    [Column("kd_Opis")]
    [StringLength(50)]
    [Unicode(false)]
    public string? KdOpis { get; set; }

    [InverseProperty("DokKategoriaDokumentu")]
    public virtual ICollection<DokDokument> DokDokuments { get; set; } = new List<DokDokument>();
}

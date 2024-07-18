using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("dok_Dokument")]
public partial class DokDokument
{
    [Key]
    [Column("dok_Id")]
    public int DokId { get; set; }

    [Column("dok_MagId")]
    public int DokMagId { get; set; }

    [Column("dok_DataWyst", TypeName = "datetime")]
    public DateTime DokDataWyst { get; set; }

    [Column("dok_KategoriaDokumentuId")]
    public int DokKategoriaDokumentuId { get; set; }

    [Column("dok_Tytul")]
    [StringLength(100)]
    public string DokTytul { get; set; } = null!;

    [Column("dok_OdbiorcaId")]
    public int DokOdbiorcaId { get; set; }

    [InverseProperty("DkpIdDokumentuNavigation")]
    public virtual ICollection<DkPozycjeNaDokumencie> DkPozycjeNaDokumencies { get; set; } = new List<DkPozycjeNaDokumencie>();

    [ForeignKey("DokKategoriaDokumentuId")]
    [InverseProperty("DokDokuments")]
    public virtual SlKategoriaDokumentu DokKategoriaDokumentu { get; set; } = null!;

    [ForeignKey("DokMagId")]
    [InverseProperty("DokDokuments")]
    public virtual SlMagazyn DokMag { get; set; } = null!;

    [ForeignKey("DokOdbiorcaId")]
    [InverseProperty("DokDokuments")]
    public virtual KhKontrahent DokOdbiorca { get; set; } = null!;
}

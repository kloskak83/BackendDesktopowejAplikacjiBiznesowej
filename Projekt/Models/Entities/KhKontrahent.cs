using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("kh_Kontrahent")]
public partial class KhKontrahent
{
    [Key]
    [Column("kh_Id")]
    public int KhId { get; set; }

    [Column("kh_Symbol")]
    [StringLength(500)]
    public string KhSymbol { get; set; } = null!;

    [Column("kh_Rodzaj")]
    public int? KhRodzaj { get; set; }

    [Column("kh_REGON")]
    [StringLength(20)]
    [Unicode(false)]
    public string? KhRegon { get; set; }

    [Column("kh_NrDowodu")]
    [StringLength(20)]
    [Unicode(false)]
    public string? KhNrDowodu { get; set; }

    [Column("kh_DataWyd", TypeName = "datetime")]
    public DateTime? KhDataWyd { get; set; }

    [Column("kh_WWW")]
    [StringLength(255)]
    [Unicode(false)]
    public string? KhWww { get; set; }

    [Column("kh_EMail")]
    [StringLength(255)]
    [Unicode(false)]
    public string? KhEmail { get; set; }

    [Column("kh_IdGrupa")]
    public int KhIdGrupa { get; set; }

    [Column("kh_IdAdresu")]
    public int KhIdAdresu { get; set; }

    [Column("kh_IdTypKontrahenta")]
    public int KhIdTypKontrahenta { get; set; }

    [Column("kh_Nazwa")]
    [StringLength(500)]
    public string? KhNazwa { get; set; }

    [Column("kh_Imie")]
    [StringLength(500)]
    public string? KhImie { get; set; }

    [Column("kh_Nazwisko")]
    [StringLength(500)]
    public string? KhNazwisko { get; set; }

    [Column("kh_FullName")]
    [StringLength(500)]
    public string? KhFullName { get; set; }

    [Column("kh_NIP")]
    [StringLength(20)]
    [Unicode(false)]
    public string? KhNip { get; set; }

    [InverseProperty("DokOdbiorca")]
    public virtual ICollection<DokDokument> DokDokuments { get; set; } = new List<DokDokument>();

    [ForeignKey("KhIdAdresu")]
    [InverseProperty("KhKontrahents")]
    public virtual AdrEwidencja KhIdAdresuNavigation { get; set; } = null!;

    [ForeignKey("KhIdGrupa")]
    [InverseProperty("KhKontrahents")]
    public virtual SlGrupaKh KhIdGrupaNavigation { get; set; } = null!;

    [ForeignKey("KhIdTypKontrahenta")]
    [InverseProperty("KhKontrahents")]
    public virtual KhTypKontrahentum KhIdTypKontrahentaNavigation { get; set; } = null!;

    [InverseProperty("WIdPodstDostawcaNavigation")]
    public virtual ICollection<TwTowar> TwTowars { get; set; } = new List<TwTowar>();
}

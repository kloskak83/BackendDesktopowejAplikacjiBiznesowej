using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("adr_Ewidencja")]
public partial class AdrEwidencja
{
    [Key]
    [Column("adr_Id")]
    public int AdrId { get; set; }

    [Column("adr_Nazwa")]
    [StringLength(51)]
    [Unicode(false)]
    public string? AdrNazwa { get; set; }

    [Column("adr_NazwaPelna")]
    [StringLength(255)]
    [Unicode(false)]
    public string? AdrNazwaPelna { get; set; }

    [Column("adr_Telefon")]
    [StringLength(35)]
    [Unicode(false)]
    public string? AdrTelefon { get; set; }

    [Column("adr_Ulica")]
    [StringLength(60)]
    [Unicode(false)]
    public string? AdrUlica { get; set; }

    [Column("adr_NrDomu")]
    [StringLength(10)]
    [Unicode(false)]
    public string? AdrNrDomu { get; set; }

    [Column("adr_NrLokalu")]
    [StringLength(10)]
    [Unicode(false)]
    public string? AdrNrLokalu { get; set; }

    [Column("adr_Kod")]
    [StringLength(8)]
    [Unicode(false)]
    public string? AdrKod { get; set; }

    [Column("adr_Miejscowosc")]
    [StringLength(40)]
    [Unicode(false)]
    public string? AdrMiejscowosc { get; set; }

    [Column("adr_IdWojewodztwo")]
    public int? AdrIdWojewodztwo { get; set; }

    [Column("adr_IdPanstwo")]
    public int? AdrIdPanstwo { get; set; }

    [Column("adr_Poczta")]
    [StringLength(40)]
    [Unicode(false)]
    public string? AdrPoczta { get; set; }

    [Column("adr_Gmina")]
    [StringLength(40)]
    [Unicode(false)]
    public string? AdrGmina { get; set; }

    [Column("adr_Powiat")]
    [StringLength(40)]
    [Unicode(false)]
    public string? AdrPowiat { get; set; }

    [Column("adr_DataZmiany", TypeName = "datetime")]
    public DateTime? AdrDataZmiany { get; set; }

    [ForeignKey("AdrIdPanstwo")]
    [InverseProperty("AdrEwidencjas")]
    public virtual SlPanstwo? AdrIdPanstwoNavigation { get; set; }

    [ForeignKey("AdrIdWojewodztwo")]
    [InverseProperty("AdrEwidencjas")]
    public virtual SlWojewodztwo? AdrIdWojewodztwoNavigation { get; set; }

    [InverseProperty("KhIdAdresuNavigation")]
    public virtual ICollection<KhKontrahent> KhKontrahents { get; set; } = new List<KhKontrahent>();
}

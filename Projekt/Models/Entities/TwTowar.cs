using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("tw_Towar")]
public partial class TwTowar
{
    [Key]
    [Column("tw_Id")]
    public int TwId { get; set; }

    [Column("tw_Symbol")]
    [StringLength(50)]
    public string TwSymbol { get; set; } = null!;

    [Column("tw_Nazwa")]
    [StringLength(200)]
    public string TwNazwa { get; set; } = null!;

    [Column("tw_Opis")]
    [StringLength(255)]
    [Unicode(false)]
    public string? TwOpis { get; set; }

    [Column("w_IdPodstDostawca")]
    public int WIdPodstDostawca { get; set; }

    [Column("tw_IdGrupa")]
    public int TwIdGrupa { get; set; }

    [Column("tw_Usuniety")]
    public bool? TwUsuniety { get; set; }

    [Column("tw_CenaZakupu", TypeName = "money")]
    public decimal TwCenaZakupu { get; set; }

    [InverseProperty("DkpIdTowaruNavigation")]
    public virtual ICollection<DkPozycjeNaDokumencie> DkPozycjeNaDokumencies { get; set; } = new List<DkPozycjeNaDokumencie>();

    [InverseProperty("PwtIdTowarNavigation")]
    public virtual ICollection<SlPolaWlasneTowarow> SlPolaWlasneTowarows { get; set; } = new List<SlPolaWlasneTowarow>();

    [InverseProperty("ChtIdTowarNavigation")]
    public virtual ICollection<TwCechaTw> TwCechaTws { get; set; } = new List<TwCechaTw>();

    [InverseProperty("TcIdTowarNavigation")]
    public virtual ICollection<TwCena> TwCenas { get; set; } = new List<TwCena>();

    [ForeignKey("TwIdGrupa")]
    [InverseProperty("TwTowars")]
    public virtual SlGrupaTw TwIdGrupaNavigation { get; set; } = null!;

    [ForeignKey("WIdPodstDostawca")]
    [InverseProperty("TwTowars")]
    public virtual KhKontrahent WIdPodstDostawcaNavigation { get; set; } = null!;
}

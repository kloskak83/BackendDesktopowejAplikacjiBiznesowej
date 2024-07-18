using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("dk_PozycjeNaDokumencie")]
public partial class DkPozycjeNaDokumencie
{
    [Key]
    [Column("dkp_Id")]
    public int DkpId { get; set; }

    [Column("dkp_IdTowaru")]
    public int? DkpIdTowaru { get; set; }

    [Column("dkp_IdDokumentu")]
    public int? DkpIdDokumentu { get; set; }

    [Column("tc_CenaNettNaDokumencie", TypeName = "money")]
    public decimal TcCenaNettNaDokumencie { get; set; }

    [Column("dkp_Ilosc")]
    public double DkpIlosc { get; set; }

    [ForeignKey("DkpIdDokumentu")]
    [InverseProperty("DkPozycjeNaDokumencies")]
    public virtual DokDokument? DkpIdDokumentuNavigation { get; set; }

    [ForeignKey("DkpIdTowaru")]
    [InverseProperty("DkPozycjeNaDokumencies")]
    public virtual TwTowar? DkpIdTowaruNavigation { get; set; }
}

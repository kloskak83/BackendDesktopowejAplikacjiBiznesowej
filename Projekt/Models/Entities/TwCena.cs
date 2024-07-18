using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("tw_Cena")]
public partial class TwCena
{
    [Key]
    [Column("tc_Id")]
    public int TcId { get; set; }

    [Column("tc_IdTowar")]
    public int TcIdTowar { get; set; }

    [Column("tc_CenaNetto1", TypeName = "money")]
    public decimal TcCenaNetto1 { get; set; }

    [Column("tc_CenaNetto2", TypeName = "money")]
    public decimal TcCenaNetto2 { get; set; }

    [Column("tc_CenaNetto3", TypeName = "money")]
    public decimal TcCenaNetto3 { get; set; }

    [Column("tc_CenaNetto4", TypeName = "money")]
    public decimal TcCenaNetto4 { get; set; }

    [Column("tc_CenaBrutto1", TypeName = "money")]
    public decimal TcCenaBrutto1 { get; set; }

    [Column("tc_CenaBrutto2", TypeName = "money")]
    public decimal TcCenaBrutto2 { get; set; }

    [Column("tc_CenaBrutto3", TypeName = "money")]
    public decimal TcCenaBrutto3 { get; set; }

    [Column("tc_CenaBrutto4", TypeName = "money")]
    public decimal TcCenaBrutto4 { get; set; }

    [Column("tc_NazwaCena1Id")]
    public int TcNazwaCena1Id { get; set; }

    [Column("tc_NazwaCena2Id")]
    public int TcNazwaCena2Id { get; set; }

    [Column("tc_NazwaCena3Id")]
    public int TcNazwaCena3Id { get; set; }

    [Column("tc_NazwaCena4Id")]
    public int TcNazwaCena4Id { get; set; }

    [Column("tc_CenaNettoZakupu", TypeName = "money")]
    public decimal? TcCenaNettoZakupu { get; set; }

    [ForeignKey("TcIdTowar")]
    [InverseProperty("TwCenas")]
    public virtual TwTowar TcIdTowarNavigation { get; set; } = null!;
}

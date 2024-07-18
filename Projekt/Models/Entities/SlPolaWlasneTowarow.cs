using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("sl_PolaWlasneTowarow")]
public partial class SlPolaWlasneTowarow
{
    [Key]
    [Column("pwt_Id")]
    public int PwtId { get; set; }

    [Column("pwt_IdTowar")]
    public int? PwtIdTowar { get; set; }

    [Column("pwt_IdPoleWlasne")]
    public int? PwtIdPoleWlasne { get; set; }

    [ForeignKey("PwtIdPoleWlasne")]
    [InverseProperty("SlPolaWlasneTowarows")]
    public virtual SlPolaWlasne? PwtIdPoleWlasneNavigation { get; set; }

    [ForeignKey("PwtIdTowar")]
    [InverseProperty("SlPolaWlasneTowarows")]
    public virtual TwTowar? PwtIdTowarNavigation { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("tw_CechaTw")]
public partial class TwCechaTw
{
    [Key]
    [Column("cht_Id")]
    public int ChtId { get; set; }

    [Column("cht_IdTowar")]
    public int? ChtIdTowar { get; set; }

    [Column("cht_IdCecha")]
    public int? ChtIdCecha { get; set; }

    [ForeignKey("ChtIdCecha")]
    [InverseProperty("TwCechaTws")]
    public virtual SlCechaTw? ChtIdCechaNavigation { get; set; }

    [ForeignKey("ChtIdTowar")]
    [InverseProperty("TwCechaTws")]
    public virtual TwTowar? ChtIdTowarNavigation { get; set; }
}

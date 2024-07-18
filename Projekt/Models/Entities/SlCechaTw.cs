using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("sl_CechaTw")]
public partial class SlCechaTw
{
    [Key]
    [Column("ctw_Id")]
    public int CtwId { get; set; }

    [Column("ctw_Nazwa")]
    [StringLength(100)]
    public string CtwNazwa { get; set; } = null!;

    [InverseProperty("ChtIdCechaNavigation")]
    public virtual ICollection<TwCechaTw> TwCechaTws { get; set; } = new List<TwCechaTw>();
}

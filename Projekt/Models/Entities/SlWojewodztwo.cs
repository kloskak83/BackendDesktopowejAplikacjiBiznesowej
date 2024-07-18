using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("sl_Wojewodztwo")]
public partial class SlWojewodztwo
{
    [Key]
    [Column("woj_Id")]
    public int WojId { get; set; }

    [Column("woj_Nazwa")]
    [StringLength(35)]
    public string WojNazwa { get; set; } = null!;

    [InverseProperty("AdrIdWojewodztwoNavigation")]
    public virtual ICollection<AdrEwidencja> AdrEwidencjas { get; set; } = new List<AdrEwidencja>();
}

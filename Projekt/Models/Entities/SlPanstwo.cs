using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Table("sl_Panstwo")]
public partial class SlPanstwo
{
    [Key]
    [Column("pa_Id")]
    public int PaId { get; set; }

    [Column("pa_Nazwa")]
    [StringLength(100)]
    public string PaNazwa { get; set; } = null!;

    [Column("pa_KodPanstwaUE")]
    [StringLength(2)]
    [Unicode(false)]
    public string? PaKodPanstwaUe { get; set; }

    [InverseProperty("AdrIdPanstwoNavigation")]
    public virtual ICollection<AdrEwidencja> AdrEwidencjas { get; set; } = new List<AdrEwidencja>();
}

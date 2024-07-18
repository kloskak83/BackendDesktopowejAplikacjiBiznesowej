using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models.Entities;

[Keyless]
[Table("SlCennik")]
[Index("SlCId", Name = "UQ__SlCennik__143F5A490A0EBE96", IsUnique = true)]
[Index("SlCNazwa", Name = "UnikalnaNazwa", IsUnique = true)]
public partial class SlCennik
{
    [Column("slC_Id")]
    public int SlCId { get; set; }

    [Column("slC_Nazwa")]
    [StringLength(50)]
    public string SlCNazwa { get; set; } = null!;
}

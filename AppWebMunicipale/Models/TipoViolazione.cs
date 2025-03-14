using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppWebMunicipale.Models;

[Table("TipoViolazione")]
public partial class TipoViolazione
{
    [Key]
    [Column("idViolazione")]
    public int IdViolazione { get; set; }

    [StringLength(255)]
    public string Descrizione { get; set; } = null!;

    [InverseProperty("IdViolazioneNavigation")]
    public virtual ICollection<Verbale> Verbales { get; set; } = new List<Verbale>();
}

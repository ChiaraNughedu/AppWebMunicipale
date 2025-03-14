using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppWebMunicipale.Models;

[Table("Anagrafica")]
public partial class Anagrafica
{
    [Key]
    [Column("idAnagrafica")]
    public int IdAnagrafica { get; set; }

    [StringLength(50)]
    public string Cognome { get; set; } = null!;

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [StringLength(100)]
    public string? Indirizzo { get; set; }

    [StringLength(50)]
    public string? Città { get; set; }

    [Column("CAP")]
    [StringLength(5)]
    public string? Cap { get; set; }

    [Column("Cod_Fisc")]
    [StringLength(16)]
    [Unicode(false)]
    public string CodFisc { get; set; } = null!;

    [InverseProperty("IdAnagraficaNavigation")]
    public virtual ICollection<Verbale> Verbales { get; set; } = new List<Verbale>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppWebMunicipale.Models;

[Table("Verbale")]
public partial class Verbale
{
    [Key]
    [Column("idVerbale")]
    public int IdVerbale { get; set; }

    public DateOnly DataViolazione { get; set; }

    [StringLength(100)]
    public string? IndirizzoViolazione { get; set; }

    [StringLength(100)]
    public string? NominativoAgente { get; set; }

    public DateOnly DataTrascrizioneVerbale { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Importo { get; set; }

    public int? DecurtamentoPunti { get; set; }

    [Column("idAnagrafica")]
    public int? IdAnagrafica { get; set; }

    [Column("idViolazione")]
    public int? IdViolazione { get; set; }

    [ForeignKey("IdAnagrafica")]
    [InverseProperty("Verbales")]
    public virtual Anagrafica? IdAnagraficaNavigation { get; set; }

    [ForeignKey("IdViolazione")]
    [InverseProperty("Verbales")]
    public virtual TipoViolazione? IdViolazioneNavigation { get; set; }
}

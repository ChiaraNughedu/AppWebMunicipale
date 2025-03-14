namespace AppWebMunicipale.Models
{
    public class ViolazioniOver400
    {
        public int IdVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public required string IndirizzoViolazione { get; set; }
        public required string NominativoAgente { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
    }
}

namespace AppWebMunicipale.Models
{
    public class Verbali
    {
        public required int TrasgressoreId { get; set; }
        public required string TrasgressoreNome { get; set; } // Se vuoi visualizzare il nome
        public required List<Verbale> Verbalis { get; set; }
    }
}

namespace AppWebMunicipale.Models
{
    public class Punti
    {
        public int TrasgressoreId { get; set; }
        public required string TrasgressoreNome { get; set; } // Se vuoi visualizzare il nome
        public int TotalePunti { get; set; }
    }
}

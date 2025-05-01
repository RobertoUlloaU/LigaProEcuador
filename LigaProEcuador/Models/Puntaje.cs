namespace LigaProEcuador.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Puntaje
    {
        [Key]
        public int Id { get; set; }  

        public int PartidosGanados { get; set; }
        public int PartidosEmpatados { get; set; }

        public int Puntos => (PartidosGanados * 3) + (PartidosEmpatados * 1);  // Calcula los puntos basado en los partidos ganados y empatados
    }



}

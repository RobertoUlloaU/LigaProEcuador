namespace LigaProEcuador.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Equipo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }
        public string Logo { get; set; }
        public string Descripcion { get; set; }

        public int PartidosJugados { get; set; }
        public int PartidosGanados { get; set; }
        public int PartidosEmpatados { get; set; }
        public int PartidosPerdidos { get; set; }
        public int Puntos { get; set; }

        // Relacion con jugadores (1 a muchos)
        public ICollection<Jugador> Jugadores { get; set; }

        // Metodo para calcular puntos (puedes también ponerlo en el controlador si prefieres)
        public void CalcularPuntos()
        {
            Puntos = (PartidosGanados * 3) + (PartidosEmpatados * 1);
        }
    }


}

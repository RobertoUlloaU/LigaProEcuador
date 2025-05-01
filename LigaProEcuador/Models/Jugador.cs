namespace LigaProEcuador.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Jugador
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }
        public int NumeroCamiseta { get; set; }
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public decimal Sueldo { get; set; }

        // Clave foránea para equipo (relación con Equipo)
        [ForeignKey("Equipo")]
        public int EquipoId { get; set; }

        // Relación con equipo (1 a 1)
        public Equipo Equipo { get; set; }
    }


}

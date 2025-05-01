namespace LigaProEcuador.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Posicion
    {
        [Key]
        public int Id { get; set; }

        // Clave foranea para equipo (relación con Equipo)
        [ForeignKey("Equipo")]
        public int EquipoId { get; set; }

        public int PosicionActual { get; set; }
        public int Puntos { get; set; }

        // Relacion con equipo (1 a 1)
        public Equipo Equipo { get; set; }
    }


}

namespace LigaProEcuador.Models
{
    using System.Collections.Generic;

    public class Reporte
    {
        public List<Jugador> Goleadores { get; set; }
        public List<Jugador> JugadoresConMasAsistencias { get; set; }
        public List<Equipo> EquiposConMasPresupuesto { get; set; }

        public Reporte(List<Jugador> goleadores, List<Jugador> jugadoresConMasAsistencias, List<Equipo> equiposConMasPresupuesto)
        {
            Goleadores = goleadores;
            JugadoresConMasAsistencias = jugadoresConMasAsistencias;
            EquiposConMasPresupuesto = equiposConMasPresupuesto;
        }
    }


}

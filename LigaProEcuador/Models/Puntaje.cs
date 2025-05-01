namespace LigaProEcuador.Models
{
    public class Puntaje
    {
        public static int CalcularPuntos(int partidosGanados, int partidosEmpatados)
        {
            // Victoria suma 3 puntos, empate suma 1 punto
            return (partidosGanados * 3) + (partidosEmpatados * 1);
        }
    }


}

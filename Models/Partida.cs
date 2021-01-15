using System;

namespace EPlayers_AspNet.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public int idJogador1 { get; set; }
        public int idJogador2 { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioTermino { get; set; }

    }
}
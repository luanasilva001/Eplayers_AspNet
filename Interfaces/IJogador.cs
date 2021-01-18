using System.Collections.Generic;
using EPlayers_AspNet.Models;

namespace EPlayers_AspNet.Interfaces
{
    public interface IJogador
    {
         void Create (Jogador jogador);

         List<Jogador> ReadAll();

         void Update();
         void Delete();
    }
}
using System.Collections.Generic;
using EPlayers_AspNet.Models;

namespace EPlayers_AspNet
{
    public interface IEquipe
    {
         void Create(Equipe e);
         List<Equipe> ReadAll();

         void Update(Equipe e);
         void Delete(int id);
         

    }
}
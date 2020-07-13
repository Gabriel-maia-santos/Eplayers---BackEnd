using System.Collections.Generic;

namespace E_players_Back_end.Interfaces
{
    public interface IEquipe
    {
        /// <summary>
        /// CRUD
        /// </summary>
        /// <param name="t"></param>
         void Create(Equipe t);

         List<Equipe> ReadAll();

         void Update(Equipe e);
         void Delete(int IdEquipe);
    }
}
using System.Collections.Generic;
using E_players_Back_end.Models;

namespace E_players_Back_end.Interfaces
{
    public interface INoticia
    {
         /// <summary>
        /// CRUD
        /// </summary>
        /// <param name="t"></param>
         void Create(Noticia n);

         List<Noticia> ReadAll();

         void Update(Noticia n);
         void Delete(int IdNoticias);
    }
}
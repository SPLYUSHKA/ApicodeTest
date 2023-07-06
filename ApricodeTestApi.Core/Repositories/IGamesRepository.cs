using ApricodeTestApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApricodeTestApi.Core.Repositories
{
    public interface IGamesRepository : IRepository<Game>
    {
        /// <summary>
        /// Получает список игр, отфильтрованный по жанру игры.
        /// </summary>
        /// <param name="genreId">Идентификатор жанра игры</param>
        /// <returns>Возвращает список игр, у которых Genres содержит указанный жанр</returns>
        Task<List<Game>> GetGamesByGenreAsync(int genreId);
    }
}

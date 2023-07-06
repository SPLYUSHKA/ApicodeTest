using ApricodeTestApi.Core.Entities;
using ApricodeTestApi.Core.Errors;
using ApricodeTestApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AprocodeTestApi.Data.EntityFramework
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GamesContext context;

        public GamesRepository(GamesContext context)
        {
            this.context = context;
        }

        public async Task<Game?> FindAsync(int id)
        {
            return await context.Games.FindAsync(id);
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await context.Games
                .Include(g => g.Developer)
                .Include(g => g.Genres)
                .ToListAsync();
        }

        public async Task<List<Game>> GetGamesByGenreAsync(int genreId)
        {
            return await context
                .Games
                .Include(g => g.Developer)
                .Include(g => g.Genres)
                .Where(game => game.Genres.Any(genre => genre.Id == genreId))
                .ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var toRemove = await context.Games.FindAsync(id);
            if (toRemove != null)
            {
                context.Games.Remove(toRemove);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException($"Игра {id} не найдена");
            }
        }
        
        private async Task<bool> isCorrectDeveloper(int developerId)
        {
            return await context.Developers.FindAsync(developerId) is not null;
        }

        private async Task checkDeveloper(Game item)
        {
            bool hasDeveloper = await isCorrectDeveloper(item.DeveloperId);
            if (!hasDeveloper)
            {
                throw new NotFoundException($"Студия {item.DeveloperId} не найдена");
            }
        }

        private async Task checkGenres(Game item)
        {
            foreach (Genre genre in item.Genres)
            {
                if (!await context.Genres.ContainsAsync(genre))
                {
                    throw new NotFoundException($"Жанр {genre.Id} не найден");
                }
            }
        }
        public async Task checkGameExists(int gameId) 
        {
            if (await context.Games
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == gameId) is null) 
            {
                throw new NotFoundException($"Игра {gameId} не найдена");
            }
        }

        public async Task<Game> AddAsync(Game item)
        {
            await checkDeveloper(item);
            await checkGenres(item);

            // перезагружаем названия жанров по Id,
            // несуществующие жанры будут иметь EntityState == Untracked
            foreach (Genre genre in item.Genres)
            {
                context.Entry(genre).Reload();
            }

            // выполняем добавление
            context.Entry(item).State = EntityState.Added;

            // сохраняем изменения 
            await context.SaveChangesAsync();
            // загрузка, чтобы вывести в ответе пользователю название студии
            await context.Entry(item).Reference(game => game.Developer).LoadAsync();
            return item;
        }

        
        public async Task<Game> UpdateAsync(Game item)
        {
            await checkGameExists(item.Id);
            await checkDeveloper(item);
            await checkGenres(item);
            
            // загружаем новый список жанров в отдельный лист 
            List<Genre> genres = new List<Genre>();
            foreach (Genre genre in item.Genres)
            {
                context.Entry(genre).Reload();
                if (context.Entry(genre).State != EntityState.Detached)
                {
                    genres.Add(genre);
                }
            }
            item.Genres.Clear();

            // удаляем существующие ранее жанры (Clear) и добавляем новые из сохраненного листа
            // (это заставит EF изменить значения в таблице GameGenre)
            context.Attach(item).Collection(game => game.Genres).Load();
            item.Genres.Clear();

            foreach (Genre genre in genres)
            {
                item.Genres.Add(genre);
            }
            context.Entry(item).State = EntityState.Modified;
            // сохраняем изменения 
            await context.SaveChangesAsync();
            // загрузка, чтобы вывести в ответе пользователю название студии
            await context.Entry(item).Reference(game => game.Developer).LoadAsync();
            return item;
        }
    }
}

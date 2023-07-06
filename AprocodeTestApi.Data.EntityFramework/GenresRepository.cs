using ApricodeTestApi.Core.Entities;
using ApricodeTestApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprocodeTestApi.Data.EntityFramework
{
    public class GenresRepository : IRepository<Genre>
    {
        private readonly GamesContext context;

        public GenresRepository(GamesContext context) 
        {
            this.context = context;
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await context.Genres.ToListAsync();
        }


        // TODO: Остальные методы доделать позже, не предполагалось по заданию

        public Task<Genre> AddAsync(Genre item)
        {
            throw new NotImplementedException();
        }

        public Task<Genre?> FindAsync(int id)
        {
            throw new NotImplementedException();
        }



        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> UpdateAsync(Genre item)
        {
            throw new NotImplementedException();
        }
    }
}

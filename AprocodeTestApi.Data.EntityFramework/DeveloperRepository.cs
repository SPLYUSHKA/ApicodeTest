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
    public class DeveloperRepository : IRepository<Developer>
    {
        private readonly GamesContext context;

        public DeveloperRepository(GamesContext context) 
        {
            this.context = context;
        }

        public async Task<List<Developer>> GetAllAsync()
        {
            return await context.Developers.ToListAsync();
        }



        // TODO: Остальные методы доделать позже, не предполагалось по заданию

        public Task<Developer> AddAsync(Developer item)
        {
            throw new NotImplementedException();
        }

        public Task<Developer?> FindAsync(int id)
        {
            throw new NotImplementedException();
        }



        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Developer> UpdateAsync(Developer item)
        {
            throw new NotImplementedException();
        }
    }
}

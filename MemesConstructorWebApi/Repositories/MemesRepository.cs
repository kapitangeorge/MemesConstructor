using MemesConstructorWebApi.Context;
using MemesConstructorWebApi.Domain.Models;
using MemesConstructorWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Repositories
{
    public class MemesRepository : IMemesRepository
    {
        private readonly AppDbContext database;

        public MemesRepository(AppDbContext context)
        {
            database = context;
        }
        public async Task AddMem(Mem mem)
        {
            await database.Memes.AddAsync(mem);
            await database.SaveChangesAsync();

        }

        public async Task DeleteMem(Mem mem)
        {
            database.Memes.Remove(mem);
            await database.SaveChangesAsync();
        }

        public async Task<Mem> GetMem(int memId)
        {
            return await database.Memes.FirstOrDefaultAsync(m => m.Id == memId);
        }

        public async Task<IEnumerable<Mem>> GetMemes()
        {
            return await database.Memes.ToListAsync();
        }

        public async Task UpdateMem(Mem mem)
        {
            database.Update(mem);
            await database.SaveChangesAsync();
        }
    }
}

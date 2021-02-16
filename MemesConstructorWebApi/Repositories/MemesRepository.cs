using MemesConstructorWebApi.Context;
using MemesConstructorWebApi.Interfaceses;
using MemesConstructorWebApi.Models;
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
        public async Task<Mem> AddMem(Mem mem)
        {
            var result = await database.Memes.AddAsync(mem);
            await database.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Mem> DeleteMem(int memId)
        {
            var result = await database.Memes
            .FirstOrDefaultAsync(m => m.Id == memId);
            if (result != null)
            {
                database.Memes.Remove(result);
                await database.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Mem> GetMem(int memId)
        {
            return await database.Memes.FirstOrDefaultAsync(m => m.Id == memId);
        }

        public async Task<IEnumerable<Mem>> GetMemes()
        {
            return await database.Memes.ToListAsync(); 
        }

        public async Task<Mem> UpdateMem(Mem mem)
        {
            var result = await database.Memes.FirstOrDefaultAsync(m => m.Id == mem.Id);

            if(result != null)
            {
                result.Name = mem.Name;
                result.Description = mem.Description;
                result.ImagePath = mem.ImagePath;

                database.Update(result);
                await database.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}

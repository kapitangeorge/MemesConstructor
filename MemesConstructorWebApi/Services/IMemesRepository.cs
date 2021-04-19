using MemesConstructorWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Interfaces
{
    public interface IMemesRepository
    {
        Task<IEnumerable<Mem>> GetMemes();
        Task<Mem> GetMem(int memId);
        Task AddMem(Mem mem);
        Task UpdateMem(Mem mem);
        Task DeleteMem(Mem mem);
    }
}

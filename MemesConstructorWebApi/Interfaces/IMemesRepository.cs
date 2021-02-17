using MemesConstructorWebApi.Models;
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
        Task<Mem> AddMem(Mem mem);
        Task<Mem> UpdateMem(Mem mem);
        Task<Mem> DeleteMem(int memId);
    }
}

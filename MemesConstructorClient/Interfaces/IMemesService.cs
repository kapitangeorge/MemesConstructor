﻿using MemesConstructorClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorClient.Interfaces
{
    public interface IMemesService
    {
        Task<IEnumerable<Mem>> GetMemes();
        Task<Mem> AddNewMem(Mem mem);
    }
}

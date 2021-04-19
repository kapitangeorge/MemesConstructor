using MemesConstructorWebApi.Interfaces;
using MemesConstructorWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Services
{
    public class MemesService
    {
        private readonly IMemesRepository repository;

        public MemesService(IMemesRepository memesRepository)
        {
            repository = memesRepository;
        }


    }
}

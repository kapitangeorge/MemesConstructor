using MemesConstructorClient.Interfaces;
using MemesConstructorClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MemesConstructorClient.Services
{
    public class MemesService : IMemesService
    {
        private readonly HttpClient httpClient;

        public MemesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Mem>> GetMemes()
        {
            return await httpClient.GetFromJsonAsync<Mem[]>("api/Memes");
        }

        public async Task<Mem> AddNewMem(Mem mem)
        {
            var result = await httpClient.PostAsJsonAsync("api/Memes", mem);
            return await result.Content.ReadFromJsonAsync<Mem>();
        }

        public async Task<Mem> GetMemById(int id)
        {
            return await httpClient.GetFromJsonAsync<Mem>($"api/Memes/{id}");
        }
    }
}

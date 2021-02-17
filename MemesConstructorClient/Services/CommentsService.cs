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
    public class CommentsService : ICommentsService
    {
        private readonly HttpClient httpClient;

        public CommentsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Comment> CreateComment(Comment comment)
        {
            var result = await httpClient.PostAsJsonAsync("api/Comments", comment);
            return await result.Content.ReadFromJsonAsync<Comment>();
        }

        public async Task<IEnumerable<Comment>> GetComments(int memId) 
        {
            return await httpClient.GetFromJsonAsync<List<Comment>>($"api/Comments/GetCommentsByMemId/{memId}");
        }

        public async Task<Comment> UpdateComment(Comment comment, int id)
        {
            var result = await httpClient.PutAsJsonAsync($"api/Comments/{id}", comment);
            return await result.Content.ReadFromJsonAsync<Comment>();
        }
    }
}

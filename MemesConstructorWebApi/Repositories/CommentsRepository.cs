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
    public class CommentsRepository : ICommentsRepository
    {
        private readonly AppDbContext database;
       

        public CommentsRepository(AppDbContext context)
        {
            database = context;
        }

        public async Task CreateComment(Comment comment)
        {
            await database.Comments.AddAsync(comment);
            await database.SaveChangesAsync();

        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await database.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetCommentByMemId(int id)
        {
            return await database.Comments.Where(c => c.Mem.Id == id).OrderByDescending(c => c.PublishDate).ToListAsync();
        }

        public async Task UpdateComment(Comment comment)
        {
            database.Comments.Update(comment);
            await database.SaveChangesAsync();
        }

        public async Task DeleteComment(Comment comment)
        {
            database.Comments.Remove(comment);
            await database.SaveChangesAsync();
        }
    }
}

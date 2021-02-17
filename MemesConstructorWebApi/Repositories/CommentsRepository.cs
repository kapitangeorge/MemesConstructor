using MemesConstructorWebApi.Context;
using MemesConstructorWebApi.Interfaces;
using MemesConstructorWebApi.Models;
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

        public async Task<Comment> CreateComment(Comment comment)
        {
            var result = await database.Comments.AddAsync(comment);
            await database.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await database.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetCommentByMemId(int id)
        {
            return await database.Comments.Where(c => c.Mem_Id == id).OrderByDescending(c => c.PublishDate).ToListAsync();
        }
    }
}

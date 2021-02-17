using MemesConstructorWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Interfaces
{
    public interface ICommentsRepository
    {
        public Task<IEnumerable<Comment>> GetCommentByMemId(int id);

        public Task<Comment> CreateComment(Comment comment);

        public Task<Comment> GetCommentById(int id);
    }
}


using MemesConstructorWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Interfaces
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comment>> GetCommentByMemId(int id);


        Task<Comment> GetCommentById(int id);

        Task UpdateComment(Comment comment);

        Task CreateComment(Comment comment);

        Task DeleteComment(Comment comment);


    }
}


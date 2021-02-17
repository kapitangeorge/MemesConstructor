using MemesConstructorClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorClient.Interfaces
{
    public interface ICommentsService
    {
        Task<IEnumerable<Comment>> GetComments(int memId);

        Task<Comment> CreateComment(Comment comment);

        Task<Comment> UpdateComment(Comment comment, int id);
    }
}

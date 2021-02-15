using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public DateTime PublishDate { get; set; }

        public int Author_Id { get; set; }

        public int Rating { get; set; }

    }
}

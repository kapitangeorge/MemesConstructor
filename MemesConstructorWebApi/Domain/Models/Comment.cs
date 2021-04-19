using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public DateTime PublishDate { get; set; }

        public int Rating { get; set; }

        public virtual Mem Mem { get; set; }

        public string TextComment { get; set; }
    }
}

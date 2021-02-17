using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorClient.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public DateTime PublishDate { get; set; }

        public int Author_Id { get; set; }

        public int Rating { get; set; }

        public int Mem_Id { get; set; }

        [Required]
        public string TextComment { get; set; }
    }
}

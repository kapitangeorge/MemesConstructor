using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Domain.Models
{
    public class Mem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public int Rating { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImagePath { get; set; }
    }
}

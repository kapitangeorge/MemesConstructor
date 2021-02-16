using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorClient.Models
{
    public class Mem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [MinLength(4,ErrorMessage = "Минимальная длина 4 символа")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Author_id { get; set; }

        public int Rating { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImagePath { get; set; }
    }
}

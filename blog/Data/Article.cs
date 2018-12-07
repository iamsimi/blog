using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Data
{
    public class Article
    {
        public int id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [MinLength(300)]
        [DataType(DataType.MultilineText)]
        public string  Content { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Tags { get; set; }

        public string datePublished { get; set; }
        public Author Author { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

    }
}

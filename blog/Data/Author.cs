using System.Collections.Generic;

namespace blog.Data
{
    public class Author
    {
        public int Id { get; set; }
       public string Fullname { get; set; }
        public string Email { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
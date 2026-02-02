
using System.ComponentModel.DataAnnotations;


namespace BlogApi.Models
{
    public class Article
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; } 

        public List<Comment> comments { get; set; } = new List<Comment>();

    }
}

using System.ComponentModel.DataAnnotations;


namespace BlogApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }

        [MaxLength(100)]
        public string Author { get; set; }

        [MaxLength(100)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } 

    }
}

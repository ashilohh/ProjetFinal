using System;
using System.Collections.Generic;
using System.Text;

namespace BlogConsole.Models
{
    internal class Comment
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Comment() { }

        public Comment(int articleId, string author, string content)
        {
            ArticleId = articleId;
            Author = author;
            Content = content;
        }

        public Comment(int id, int articleId, string author, string content) : this(articleId,  author, content) 
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Artcicle: {ArticleId} | {Author} : {Content}\n " +
                   $"Créé le: {CreatedAt:dd/MM/yyyy}";
        }
    }
}

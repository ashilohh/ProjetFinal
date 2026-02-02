using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlogConsole.Models
{
    internal class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; } 

        public List<Comment> comments { get; set; } = new List<Comment>();

        public Article()
        {
        }

        public Article(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public Article(int id, string title, string content): this(title, content)
        { 
            Id = id;
        }

        public override string ToString()
        {
            return $"#Id:{Id}#\n" +
                   $"Titre: {Title}\n {Content}\n " +
                   $"Créé le: {CreatedAt:dd/MM/yyyy} | Dernière modification le: {LastUpdatedAt:dd/MM/yyyy}\n" +
                   $"===========================================================";
        }

    }
}

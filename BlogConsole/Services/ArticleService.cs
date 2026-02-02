using BlogConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogConsole.Services
{
    internal class ArticleService
    {
        private  List<Article> _articles = new List<Article>();
        private  int _nextId = 1;
        private  CommentService _commentService;

        public List<Article> GetArticles()
        {
             return _articles;      
        }

        public Article ArticleDetails(int id)
        {
            return _articles.FirstOrDefault(a => a.Id == id);
        }

        public Article CreateArticle(string title, string content)
        {
            Article article = new Article()
            {
                Title = title,
                Content = content,
                Id = _nextId++
            };

            _articles.Add(article);
            return article;
        }

        public bool UpdateArticle(int id, string newTitle, string newContent)
        {
            Article articleToUpdate = _articles.FirstOrDefault(article => article.Id == id);

            if (articleToUpdate == null) 
            { 
                return false;
            }

            articleToUpdate.Title = newTitle;
            articleToUpdate.Content = newContent;
            articleToUpdate.LastUpdatedAt = DateTime.Now;
            return true;
        }

        public bool DeleteArticle(int id)
        {
            Article articleToDelete = _articles.FirstOrDefault(article => article.Id == id);
            

            if (articleToDelete != null)
            {
                return false;
            }

            _commentService.DeleteByArticle(id);
            _articles.Remove(articleToDelete);
            
            return true;

        }
    }
}

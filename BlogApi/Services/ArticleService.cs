using BlogApi.Data;
using BlogApi.DTOs;
using BlogApi.Models;
using System;

namespace BlogApi.Services
{
    public class ArticleService
    {
        private readonly BlogContext _context;
        private readonly CommentService _commentService;

        public ArticleService(BlogContext context, CommentService commentService)
        {
            _context = context;
            _commentService = commentService;
        }

        public List<Article> GetArticles()
        {
             return _context.Articles.ToList();      
        }

        public Article ArticleDetails(int id)
        {
            return _context.Articles.FirstOrDefault(a => a.Id == id);
        }

        public Article CreateArticle(CreateArticleDto payload)
        {
            Article article = new Article()
            {
                Title = payload.Title,
                Content = payload.Content,
            };

            _context.Articles.Add(article);
            _context.SaveChanges();
            return article;
        }

        public bool UpdateArticle(int id, UpdateArticleDto payload)
        {
            Article articleToUpdate = _context.Articles.FirstOrDefault(article => article.Id == id);

            if (articleToUpdate == null) 
            { 
                return false;
            }

            articleToUpdate.Title = payload.Title;
            articleToUpdate.Content = payload.Content;
            articleToUpdate.LastUpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteArticle(int id)
        {
            Article articleToDelete = _context.Articles.FirstOrDefault(article => article.Id == id);
            

            if (articleToDelete != null)
            {
                return false;
            }

            _commentService.DeleteByArticle(id);
            _context.Articles.Remove(articleToDelete);
            _context.SaveChanges();
            
            return true;

        }
    }
}

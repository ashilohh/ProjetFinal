using BlogConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogConsole.Services
{
    internal class CommentService
    {
        private List<Comment> _comments = new List<Comment>();


        public List<Comment> GetByArticle(int articleId)
        {
            return _comments.Where(c => c.ArticleId == articleId).ToList();
        }

        public void CreateComment(int articleId, string author, string content)
        {
            Comment comment = new Comment()
            {
                ArticleId = articleId,
                Author = author,
                Content = content
            };

            _comments.Add(comment);
        }

        public bool DeleteComment(int id)
        {
            Comment commentToDelete = _comments.FirstOrDefault(comment => comment.Id == id);


            if (commentToDelete != null)
            {
                return false;
            }

            _comments.Remove(commentToDelete);

            return true;

        }
    }
}

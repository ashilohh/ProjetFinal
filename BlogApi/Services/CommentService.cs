using BlogApi.Data;
using BlogApi.DTOs;
using BlogApi.Models;


namespace BlogApi.Services
{
    public class CommentService
    {
        private readonly BlogContext _context;

        public CommentService(BlogContext context)
        {
            _context = context;
        }

        public List<Comment> GetByArticle(int articleId)
        {
            return _context.Comments.Where(c => c.ArticleId == articleId).ToList();
        }

        public Comment CreateComment(CreateCommentDto payload)
        {
            Comment comment = new Comment()
            {
                Author = payload.Author,
                Content = payload.Content,
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public bool DeleteComment(int id)
        {
            Comment commentToDelete = _context.Comments.FirstOrDefault(comment => comment.Id == id);


            if (commentToDelete != null)
            {
                return false;
            }

            _context.Comments.Remove(commentToDelete);
            _context.SaveChanges();

            return true;

        }

        public void DeleteByArticle(int articleId)
        {
            var comments = _context.Comments.Where(c => c.ArticleId == articleId);

            foreach (Comment comment in comments)
            {
                _context.Comments.Remove(comment);
            }

            _context.SaveChanges() ;
        }

    }
}

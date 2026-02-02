using BlogApi.DTOs;
using BlogApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentsController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{articleId}")]
        public IActionResult GetCommentsByarticleId(int articleId)
        {
            var comments = new CommentService();
            return Ok(comments.GetByArticle(articleId));
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] CreateCommentDto payload)
        {
            var newComment = _commentService.CreateComment(payload);
            return CreatedAtAction(nameof(GetCommentsByarticleId), new { id = newComment.Id }, newComment);    
        }


        [HttpDelete("{commentId}")]
        public IActionResult DeleteComment(int commentId)
        {
            var comment = new CommentService();
            return Ok(comment.DeleteComment(commentId));
        }
    }
}

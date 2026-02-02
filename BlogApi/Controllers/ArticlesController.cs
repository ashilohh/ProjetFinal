using BlogApi.DTOs;
using BlogApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [Route("api/v1/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult GetAllArticles()
        {
            return Ok(_articleService.GetArticles().ToList());

        }

        [HttpGet("{id}")]
        public IActionResult GetArticleById(int id)
        {
            return Ok(_articleService.ArticleDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleDto payload)
        {
            var newArticle = _articleService.CreateArticle(payload);
            
            return CreatedAtAction(nameof(GetArticleById), new { id = newArticle.Id }, newArticle);
        }

        [HttpPut("{id}")]
        public IActionResult EditArticle(int id, [FromBody] UpdateArticleDto payload)
        {
            var article = _articleService.UpdateArticle(id, payload);
            return Ok(article);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            return Ok(_articleService.DeleteArticle(id));
        }

    }
}

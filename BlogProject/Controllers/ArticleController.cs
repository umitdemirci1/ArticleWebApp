﻿using Business.IServices;
using Business.Services;
using Core.DTOs;
using Core.Models;
using DataAccess.IRepository;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogProject.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleController(IArticleService articleService, IUnitOfWork unitOfWork)
        {
            _articleService = articleService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync();
            return Ok(articles);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishedArticles()
        {
            var articles = await _unitOfWork.Articles.FindAsync(article => article.IsPublished == true);
            return Ok(articles);
        }

        [HttpGet("WithAuthor")]
        public async Task<ActionResult<IEnumerable<Article>>> GetAllArticlesWithAuthor()
        {
            var articles = await _unitOfWork.Articles.GetPublishedArticlesWithAuthor();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticleById(int id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            var authorIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(authorIdString, out Guid authorId) || article.AppUserId != authorId)
            {
                return Forbid();
            }

            return Ok(article);
        }

        [Authorize(Roles = "Author")]
        [HttpGet("author")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByAuthor()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdString == null)
            {
                return BadRequest("Geçersiz kullanıcı ID'si.");
            }

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return BadRequest("Geçersiz kullanıcı ID'si.");
            }

            var articles = await _articleService.GetArticlesByAuthorAsync(userId);
            return Ok(articles);
        }

        [Authorize(Roles = "Author")]
        [HttpPost]
        public async Task<ActionResult> AddArticle([FromBody] ArticleDto articleDto)
        {
            if (articleDto == null)
            {
                return BadRequest();
            }

            var authorIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(authorIdString, out Guid authorId))
            {
                return BadRequest("Geçersiz yazar ID'si.");
            }

            articleDto.AppUserId = authorId;

            var articleId = await _articleService.AddArticleAsync(articleDto);
            return CreatedAtAction(nameof(GetArticleById), new { id = articleId }, articleDto);
        }

        [Authorize(Roles = "Author")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticle(int id, [FromBody] Article article)
        {
            if (article == null || article.Id != id)
            {
                return BadRequest();
            }

            var existingArticle = await _articleService.GetArticleByIdAsync(id);
            if (existingArticle == null)
            {
                return NotFound();
            }

            var authorIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(authorIdString, out Guid authorId) || existingArticle.AppUserId != authorId)
            {
                return Forbid();
            }

            await _articleService.UpdateArticleAsync(article);
            return NoContent();
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            var authorIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(authorIdString, out Guid authorId) || article.AppUserId != authorId)
            {
                return Forbid();
            }

            await _articleService.DeleteArticleAsync(id);
            return NoContent();
        }
    }
}

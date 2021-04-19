using MemesConstructorWebApi.Domain.Models;
using MemesConstructorWebApi.Interfaces;

using MemesConstructorWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsRepository commentsRepository;

        public CommentsController(ICommentsRepository repository)
        {
            commentsRepository = repository;
        }

        [HttpGet("GetCommentsByMemId/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int id)
        {
            try
            {
                return Ok(await commentsRepository.GetCommentByMemId(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("GetCommentById/{id}")]
        public async Task<ActionResult<Comment>> GetCommentById(int id)
        {
            try
            {
                var result = await commentsRepository.GetCommentById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment([FromBody] Comment comment)
        {
            try
            {
                if (comment == null)
                    return BadRequest();

               await commentsRepository.CreateComment(comment);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new mem record");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComment(int id, Comment comment)
        {
            try
            {
                if (id != comment.Id)
                    return BadRequest("Comment ID mismatch");

                var commentToUpdate = await commentsRepository.GetCommentById(id);

                if (commentToUpdate == null)
                    return NotFound($"Comment with Id = {id} not found");

                await commentsRepository.UpdateComment(comment);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

    }
}

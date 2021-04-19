using MemesConstructorWebApi.Context;
using MemesConstructorWebApi.Domain.Models;
using MemesConstructorWebApi.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemesController : ControllerBase
    {
        private readonly IMemesRepository memesRepository;



        public MemesController(IMemesRepository repository)
        {
            memesRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mem>>> GetAllMemes()
        {
            try
            {
                return Ok(await memesRepository.GetMemes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mem>> GetMem(int id)
        {
            try
            {
                var result = await memesRepository.GetMem(id);

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
        public async Task<ActionResult> CreateMem([FromBody] Mem mem)
        {
            try
            {
                if (mem == null)
                    return BadRequest();

                await memesRepository.AddMem(mem);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new mem record");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMem(Mem mem)
        {
            try
            {
                if (mem == null)
                    return NotFound($"Mem  not found");

                await memesRepository.UpdateMem(mem);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Mem>> DeleteMem(int id)
        {
            try
            {
                var memToDelete = await memesRepository.GetMem(id);

                if (memToDelete == null)
                {
                    return NotFound($"Mem with Id = {id} not found");
                }

                await memesRepository.DeleteMem(memToDelete);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}

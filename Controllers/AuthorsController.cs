using AutoMapper;
using Evaluasi.DAL;
using Evaluasi.Dtos;
using Evaluasi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evaluasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthor _author;
        private IMapper _mapper;

        public AuthorsController(IAuthor author, IMapper mapper)
        {
            _author = author;
            _mapper = mapper;
        }

        // getAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get()
        {
            var results = await _author.GetAll();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(results));
        }

        // getById
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            var result = await _author.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<AuthorDto>(result));
        }

        // getByName
        [HttpGet("byname")]
        public async Task<ActionResult<IEnumerable<Author>>> GetByName(string Name)
        {
            var results = await _author.GetByName(Name);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(results));
        }


        // insert author
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post([FromBody] AuthorForCreateDto authortoCreateDto)
        {
            try
            {
                var author = _mapper.Map<Models.Author>(authortoCreateDto);
                var result = await _author.Insert(author);
                var AuthorDto = _mapper.Map<Dtos.AuthorDto>(result);
                return Ok(AuthorDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<authorsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Put(int id, [FromBody] AuthorForCreateDto authortoCreateDto)
        {
            try
            {
                var author = _mapper.Map<Models.Author>(authortoCreateDto);
                var result = await _author.Update(id.ToString(), author);
                var AuthorDto = _mapper.Map<Dtos.AuthorDto>(result);
                return Ok(AuthorDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<authorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _author.Delete(id.ToString());
                return Ok($"delete data id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

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
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;

        public CoursesController(ICourse course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        // getAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var results = await _course.GetAll();
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(results));
        }


        // getById
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<CourseDto>(result));
        }

        // getByName
        [HttpGet("bytitle")]
        public async Task<ActionResult<IEnumerable<Course>>> GetByTitle(string title)
        {
            var results = await _course.GetByTitle(title);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(results));
        }

        // getById
        [HttpGet("byauthor")]
        public async Task<ActionResult<IEnumerable<Course>>> GetByAuthor(int id)
        {
            var results = await _course.GetByAuthor(id);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(results));
        }

        // insert author
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseForCreateDto coursetoCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(coursetoCreateDto);
                var result = await _course.Insert(course);
                var CourseDto = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(CourseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // editById
        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> Put(int id, [FromBody] CourseForCreateDto coursetoCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(coursetoCreateDto);
                var result = await _course.Update(id.ToString(), course);
                var CourseDto = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(CourseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id.ToString());
                return Ok($"delete data id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

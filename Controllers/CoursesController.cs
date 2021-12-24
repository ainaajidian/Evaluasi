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
        public async Task<ActionResult<IEnumerable<Course>>> Get()
        {
            var results = await _course.GetAll();
            return Ok(_mapper.Map<IEnumerable<Course>>(results));
        }

        // getById
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<Course>(result));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult<Course>> Post([FromBody] CourseForCreateDto courseForCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(courseForCreateDto);
                var result = await _course.Insert(course);
                var coursedto = _mapper.Map<Models.Course>(result);
                return Ok(coursedto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // editById
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] Course course)
        {
            try
            {
               //var course = _mapper.Map<Models.Course>(courseToCreateDto);
                var result = await _course.Update(id.ToString(), course);
                //var coursedto = _mapper.Map<Models.Course>(result);
                return Ok(result);
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

        [HttpGet("bytitle")]
        public async Task<IEnumerable<Course>> GetByTitle(string title)
        {
            var results = await _course.GetByTitle(title);
            return results;
        }
    }
}

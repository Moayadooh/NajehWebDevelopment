using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesAPIController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Course> Read()
        {
            return Course.Read();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Course GetbyId(int id)
        {
            return Course.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost("{courseCode}/{courseName}/{date}")]
        public void Create(string courseCode, string courseName, string date)
        {
            Course.Create(courseCode, courseName, date);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}/{courseCode}/{courseName}/{date}")]
        public void Edit(int id, string courseCode, string courseName, string date)
        {
            Course.Edit(id, courseCode, courseName, date);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Course.Delete(id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_NorthSys_Task.Data;

namespace WebAPI_NorthSys_Task.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        // GET: api/<CoursesController>
        [HttpGet]
        public IEnumerable<Course> Read()
        {
            return Course.Read();
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public Course GetbyId(int id)
        {
            return Course.GetById(id);
        }

        // POST api/<CoursesController>
        [HttpPost("{courseCode}/{courseName}/{date}")]
        public void Create(string courseCode, string courseName, string date)
        {
            Course.Create(courseCode, courseName, date);
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}/{courseCode}/{courseName}/{date}")]
        public void Edit(int id, string courseCode, string courseName, string date)
        {
            Course.Edit(id, courseCode, courseName, date);
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Course.Delete(id);
        }
    }
}

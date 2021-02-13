using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesAPIController : ControllerBase
    {
        [HttpGet]
        public IActionResult Read()
        {
            return Ok(Course.Read());
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            return Ok(Course.GetById(id));
        }

        [HttpPost("{courseCode}/{courseName}/{date}")]
        public IActionResult Create(string courseCode, string courseName, string date)
        {
            Course.Create(courseCode, courseName, date);
            return Ok();
        }

        [HttpPut("{id}/{courseCode}/{courseName}/{date}")]
        public IActionResult Edit(int id, string courseCode, string courseName, string date)
        {
            Course.Edit(id, courseCode, courseName, date);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Course.Delete(id);
            return Ok();
        }
    }
}

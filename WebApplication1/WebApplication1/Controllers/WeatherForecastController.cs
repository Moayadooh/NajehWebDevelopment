using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.MyClasses;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        public Course course = new Course();

        [HttpGet]
        public IActionResult Read()
        {

            if (!course.isInitialized)
            {
                course.Initial();
                course.isInitialized = true;
            }
            return Ok(course.Read());
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            return Ok(course.GetById(id));
        }

        [HttpPost("{courseCode}/{courseName}/{date}")]
        public IActionResult Create(string courseCode, string courseName, string date)
        {
            course.Create(courseCode, courseName, date);
            return Ok();
        }

        [HttpPut("{id}/{courseCode}/{courseName}/{date}")]
        public IActionResult Edit(int id, string courseCode, string courseName, string date)
        {
            course.Edit(id, courseCode, courseName, date);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            course.Delete(id);
            return Ok();
        }



        [HttpGet]
        public IActionResult GetName()
        {
            return Ok("Moayad");
        }

        [HttpGet("{age}")]
        public IActionResult GetAge(int age)
        {
            return Ok(age);
        }

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

    }
}

using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CustomController : ApiController
    {
        private TVDB db = new TVDB();
        // GET: api/Custom

        [Route("api/GetSort/{sortname}")]
        public IEnumerable<ads> Get(string sortname)
        {
            var model = db.ads.OrderBy(x => x.ID);
            switch (sortname)
            {
                case "Title":
                    model = db.ads.OrderBy(x => x.Title);
                    break;
                case "Details":
                    model = db.ads.OrderBy(x => x.Details);
                    break;
                case "Rate":
                    model = db.ads.OrderBy(x => x.Rate);
                    break;
                default:
                    break;
            }
            return model;
        }

        [Route("api/GetTitleTeam/")]
        public List<string> Gettitle()
        {
            return db.ads.Select(x => x.Title).ToList();

        }

        [Route("api/GetLogin/{username}/{password}")]
        public string Getlogin(string username, string password)
        {
            return db.Employee.SingleOrDefault(x => x.Email == username
            && x.Password == password).Email;
        }
        [Route("api/GetLogin2/{username}/{password}")]
        public Employee Getlogin2(string username, string password)
        {
            return db.Employee.SingleOrDefault(x => x.Email == username
            && x.Password == password);
        }

        [Route("api/GetRate/")]
        public List<ads> getrate()
        {
            return db.ads.ToList();
        }

        [Route("api/GetRate2/")]
        public object getrate2()
        {
            var model = db.ads.Select(x => new { x.Title, x.Rate });
            return model;
        }
    }
}
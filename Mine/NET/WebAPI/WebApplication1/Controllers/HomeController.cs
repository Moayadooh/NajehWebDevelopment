using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //string url = "https://localhost:44365/api/Majors";
        string URI = "https://localhost:44365/";

        public async Task<List<Major>> GetMajorsAsync()
        {
            //HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //string jsonValue = "";
            //using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //{
            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    jsonValue = reader.ReadToEnd();
            //}
            //List<Major> majors = JsonConvert.DeserializeObject<List<Major>>(jsonValue);
            //return majors;

            //using (var client = new HttpClient())
            //{
            //    using (var response = client.GetAsync(URI))
            //    {
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var jsonString = response.Content.ReadAsStringAsync();

            //            return JsonConvert.DeserializeObject<Major[]>(jsonString).ToList();

            //        }
            //    }
            //}

            List<Major> majors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Majors");
                if (response.IsSuccessStatusCode)
                {
                    majors = await response.Content.ReadAsAsync<List<Major>>();
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
                return majors;
            }
        }

        public ActionResult Index()
        {
            return View((IEnumerable<Major>)Task.WhenAll(GetMajorsAsync()));
        }
    }
}
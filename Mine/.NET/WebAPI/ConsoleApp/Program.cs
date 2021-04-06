using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CallWebAPIAsync().Wait();
        }

        static string URI = "https://localhost:44365/";

        static async Task CallWebAPIAsync()
        {
            await GetMajors();
            //await GetMajorById();
            //await PostMajor();
            //await PutMajor();
            //await DeleteMajor();
        }

        static async Task GetMajors()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method
                HttpResponseMessage response = await client.GetAsync("api/Majors");
                if (response.IsSuccessStatusCode)
                {
                    List<Major> majors = await response.Content.ReadAsAsync<List<Major>>();
                    for (int i = 0; i < majors.Count; i++)
                    {
                        Console.WriteLine("Major ID: {0}", majors[i].ID);
                        Console.WriteLine("Major Title: {0}", majors[i].Title);
                        Console.WriteLine("Major Total Hours: {0}", majors[i].TotalHours);
                        Console.WriteLine("Major Price: {0}", majors[i].Price);
                        Console.WriteLine("Major Start Date: {0}", majors[i].StartDate);
                        Console.WriteLine("Major End Date: {0}", majors[i].EndDate);
                        Console.WriteLine("-----------------------------------------");
                    }
                }
                else
                    Console.WriteLine("Internal server Error");
            }
        }

        static async Task GetMajorById()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Enter Major ID.");
                //GET Method
                HttpResponseMessage response = await client.GetAsync("api/Majors/" + Console.ReadLine());
                if (response.IsSuccessStatusCode)
                {
                    Major majors = await response.Content.ReadAsAsync<Major>();
                    Console.WriteLine("Major ID: {0}", majors.ID);
                    Console.WriteLine("Major Title: {0}", majors.Title);
                    Console.WriteLine("Major Total Hours: {0}", majors.TotalHours);
                    Console.WriteLine("Major Price: {0}", majors.Price);
                    Console.WriteLine("Major Start Date: {0}", majors.StartDate);
                    Console.WriteLine("Major End Date: {0}", majors.EndDate);
                    Console.WriteLine("-----------------------------------------");
                }
                else
                    Console.WriteLine("Internal server Error");
            }
        }

        static async Task PostMajor()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //POST Method
                var major = new Major() { Title = "test title", TotalHours = 123, Price = 123.321, StartDate = DateTime.Parse("5/28/2016 12:53:00 AM"), EndDate = DateTime.Parse("5/28/2020 12:53:00 AM") };
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Majors", major);
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.  
                    Uri returnUrl = response.Headers.Location;
                    Console.WriteLine(returnUrl);
                }
                else
                    Console.WriteLine("Internal server Error");
            }
        }

        static async Task PutMajor()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //PUT Method
                var major = new Major() { ID = 9, Title = "test title", TotalHours = 123, Price = 123.321, StartDate = DateTime.Parse("5/28/2016 12:53:00 AM"), EndDate = DateTime.Parse("5/28/2020 12:53:00 AM") };
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Majors/" + major.ID, major);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("Internal server Error");
            }
        }

        static async Task DeleteMajor()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //DELETE Method
                int majorId = 10;
                HttpResponseMessage response = await client.DeleteAsync("api/Majors/" + majorId);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("Internal server Error");
            }
        }
    }
}

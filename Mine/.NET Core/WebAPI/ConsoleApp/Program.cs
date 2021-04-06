using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CallWebAPIAsync().Wait();
        }

        static string URI = "https://localhost:44399/";

        static async Task CallWebAPIAsync()
        {
            await GetCountries();
            //await GetCountryById();
            //await PostCountry();
            //await PutCountry();
            //await DeleteCountry();
        }

        static async Task GetCountries()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method
                HttpResponseMessage response = await client.GetAsync("api/Countries");
                if (response.IsSuccessStatusCode)
                {
                    List<Country> country = await response.Content.ReadAsAsync<List<Country>>();
                    for (int i = 0; i < country.Count; i++)
                    {
                        Console.WriteLine("Country ID: {0}", country[i].ID);
                        Console.WriteLine("Country Name: {0}", country[i].Name);
                        Console.WriteLine("Country Continent: {0}", country[i].Continent);
                        Console.WriteLine("-----------------------------------------");
                    }
                }
                else
                    Console.WriteLine("Internal server Error");
            }
        }

        static async Task GetCountryById()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Enter Country ID.");
                //GET Method
                HttpResponseMessage response = await client.GetAsync("api/Countries/" + Console.ReadLine());
                if (response.IsSuccessStatusCode)
                {
                    Country country = await response.Content.ReadAsAsync<Country>();
                    Console.WriteLine("Country ID: {0}", country.ID);
                    Console.WriteLine("Country Name: {0}", country.Name);
                    Console.WriteLine("Country Continent: {0}", country.Continent);
                    Console.WriteLine("-----------------------------------------");
                }
                else
                    Console.WriteLine("Internal server Error");
            }
        }

        static async Task PostCountry()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //POST Method
                var country = new Country() { Name = "test1", Continent = "test1" };
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Countries", country);
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

        static async Task PutCountry()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //PUT Method
                var country = new Country() { ID = 9, Name = "test2", Continent = "test2" };
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Countries/" + country.ID, country);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("Internal server Error");
            }
        }

        static async Task DeleteCountry()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //DELETE Method
                int countryId = 9;
                HttpResponseMessage response = await client.DeleteAsync("api/Countries/" + countryId);
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

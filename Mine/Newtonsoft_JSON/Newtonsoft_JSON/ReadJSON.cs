using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Newtonsoft_JSON
{
    public class ClassPosts
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
    class ReadJSON
    {
        public static void Run()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            string jsonValue = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonValue = reader.ReadToEnd();
            }

            List<ClassPosts> posts = JsonConvert.DeserializeObject<List<ClassPosts>>(jsonValue);
            for (var i = 0; i < posts.Count; i++)
            {
                Console.WriteLine(posts[i].userId);
                Console.WriteLine(posts[i].id);
                Console.WriteLine(posts[i].title);
                Console.WriteLine(posts[i].body);
            }
        }
    }
}

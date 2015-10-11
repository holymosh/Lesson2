using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync("http://localhost:63102/api/Home?id=7").Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(response);
        }
    }
}

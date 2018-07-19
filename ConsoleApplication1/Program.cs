using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace ConsoleApplication1
{
    class Program
    {

        private static string headers = "{'user-key': '{8b25a22cc8ea7c69148194ea2aae4ecf}'}";
       

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.dowjones.com/alpha/analytics");
            // Add an Accept header for JSON format.  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync(client.BaseAddress, headers).Result;
            Console.WriteLine(response.ToString());


            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
                // var products = response.Content.ReadAsStringAsync().Result;
                // Console.WriteLine(products);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }

}
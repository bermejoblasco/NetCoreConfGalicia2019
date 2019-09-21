using System;
using System.Net.Http;

namespace netcoreconfgaliciaconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            while (true)
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    try
                    {
                        Console.WriteLine($"Request {i}");
                        client.GetStringAsync("https://xxx.azurewebsites.net/api/request");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error ´{ex}");
                    }
                }
            }
            //Console.WriteLine("Press any key to finis");
            //Console.ReadKey();
        }
    }
}

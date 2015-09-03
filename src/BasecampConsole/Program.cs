using System;
using System.Linq;
using System.Threading;
using BasecampApiNet.Core;

namespace BasecampConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new BasecampApiFactory().GetApi(args[0], args[1], args[2]);

            Console.WriteLine("Your Base64 credentials are: {0}", Base64Encode(args[1] + ":" + args[2]));

            foreach (var person in api.People.GetAll().Take(2))
            {
                Console.WriteLine(person.Email);
            }

            foreach (var person in api.People.GetAll().Take(2))
            {
                Console.WriteLine(person.Email);
            }

            var singlePerson = api.People.GetAll().FirstOrDefault();

            if (singlePerson != null)
            {
                Console.WriteLine(api.People.Get(singlePerson.Id).Name);
            }

            foreach (var item in BasecampApiBase.ResponseCache.CacheDump())
            {
                Console.WriteLine(string.Format("{0}=>{1} - {2} - {3}", item.Key, item.Value.TypeString, item.Value.LastRequested.ToString("R"), item.Value.ETag));
            }

            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}

using System;
using System.Linq;
using BasecampApiNet.Core;

namespace BasecampConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new BasecampApiFactory().GetApi(args[0], args[1], args[2]);

            //useful to use with Fiddler
            Console.WriteLine("Your Base64 credentials are: {0}", Base64Encode(args[1] + ":" + args[2]));

            //test enumerable people
            Console.WriteLine("Test multiple persons");
            foreach (var x in api.People.GetAll().Take(2))
            {
                Console.WriteLine(x.AvatarUrl);
            }

            //test cache
            Console.WriteLine("\nTest multiple persons (testing cache this time)");
            foreach (var x in api.People.GetAll().Take(2))
            {
                Console.WriteLine(x.Email);
            }

            //test single person
            Console.WriteLine("\nTest single person");
            var singlePerson = api.People.GetAll().FirstOrDefault();

            if (singlePerson != null)
            {
                Console.WriteLine(api.People.Get(singlePerson.Id).Name);
            }

            //dump cache
            Console.WriteLine("\nDumping cache");
            Console.WriteLine(api.CacheDump());
            
            //clear cache
            Console.WriteLine("\nClear cache");
            api.ClearCache();

            Console.WriteLine("\nDumping cache");
            Console.WriteLine(api.CacheDump());

            //test projects
            Console.WriteLine("\nTest multiple projects");
            var projectId = 0;

            foreach (var x in api.Projects.GetAll().Take(2))
            {
                //grab an id for the next operation
                projectId = x.Id;
                Console.WriteLine(x.Name);
            }

            Console.WriteLine("\nTest single project");
            var singleProject = api.Projects.Get(projectId);

            if (singleProject != null)
            {
                Console.WriteLine(api.Projects.Get(singleProject.Id).Name);
            }

            //dump cache
            Console.WriteLine("\nDumping cache");
            Console.WriteLine(api.CacheDump());

            /*
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
             */
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}

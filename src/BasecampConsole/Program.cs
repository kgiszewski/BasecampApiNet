using System;
using System.Linq;
using System.Runtime.CompilerServices;
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

                Console.WriteLine("\nTest assigned todo list for person");
                foreach (var x in api.People.GetAssignedTodoList(singlePerson.Id))
                {
                    Console.WriteLine("Todo List Id: {0}", x.Id);
                    Console.WriteLine("Creator: {0}", x.Creator.Name);

                    Console.WriteLine("\nTest assigned todos on list for person");
                    foreach (var y in x.AssignedTodos)
                    {
                        Console.WriteLine("{0}", y.Content);
                        Console.WriteLine("Creator: {0}", y.Creator.Name);
                    }
                }
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

            Console.WriteLine("\nDumping cache");
            Console.WriteLine(api.CacheDump());

            foreach (var x in api.Projects.GetAll().Take(2))
            {
                //grab an id for the next operation
                projectId = x.Id;
                Console.WriteLine(x.Name);
            }

            Console.WriteLine("\nDumping cache");
            Console.WriteLine(api.CacheDump());

            Console.WriteLine("\nTest single project");
            var singleProject = api.Projects.Get(projectId);

            if (singleProject != null)
            {
                Console.WriteLine(api.Projects.Get(singleProject.Id).Name);
            }

            //todos
            Console.WriteLine("\nTodos for project");
            foreach (var todo in api.Todos.GetAllForProject(projectId))
            {
                Console.WriteLine("{0} - {1}", todo.Id, todo.Content);
            }

            //dump cache
            Console.WriteLine("\nDumping cache");
            Console.WriteLine(api.CacheDump());

            //success
            Console.WriteLine("\nSUCCESS!!!!\n");

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

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

            if (api == null)
            {
                throw new Exception("API not initialized!");
            }

            //test enumerable people
            Console.WriteLine("Test multiple persons");
            foreach (var x in api.People.GetAll().Take(2))
            {
                Console.WriteLine(x.AvatarUrl);
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

            //test projects
            Console.WriteLine("\nTest multiple projects");
            var projectId = 0;
            var projects = api.Projects.GetAll();

            Console.WriteLine("Total projects: {0}", projects.Count());

            foreach (var x in projects)
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

            foreach (var todo in api.Projects.GetTodos(projectId))
            {
                Console.WriteLine("{0} - {1}", todo.Id, todo.Content);
            }

            //events
            Console.WriteLine("\nEvents");

            foreach (var _event in api.Events.GetAll(DateTime.UtcNow.AddDays(-20)))
            {
                Console.WriteLine("\n{0}", _event.Summary);
            }

            foreach (var _event in api.Projects.GetEvents(projectId, DateTime.UtcNow.AddDays(-20)))
            {
                Console.WriteLine("\n{0}", _event.Summary);
            }

            foreach (var _event in api.People.GetEvents(singlePerson.Id, DateTime.UtcNow.AddDays(-20)))
            {
                Console.WriteLine("\n{0}", _event.Summary);
            }

            //dump cache
            Console.WriteLine("\nDumping cache");
            Console.WriteLine(api.CacheDump());

            //success
            Console.WriteLine("\nSUCCESS!!!!\n");
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}

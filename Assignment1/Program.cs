using Assignment1.Models;
using System;


namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Client> clientList = new List<Client>();
            ClientMenu(clientList);
            List<Project> projectList = new List<Project>();
            ProjectMenu(projectList, clientList);

        }
        //private List<Project> projects = new List<Project>();

        static void ClientMenu(List<Client> clientList)
        {
            while (true)
            {
                Console.WriteLine("C. Create Client");
                Console.WriteLine("R. List Clients");
                Console.WriteLine("U. Update Client");
                Console.WriteLine("D. Delete Client");
                Console.WriteLine("Q. Quit");


                var choice = Console.ReadLine() ?? string.Empty;

                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    //create
                    Console.WriteLine("Id: ");
                    var Id = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("OpenDate: ");
                    var open = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                    Console.WriteLine("ClosedDate: ");
                    var close = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                    Console.WriteLine("IsActive: true ");
                    var active = true;

                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();

                    Console.WriteLine("Notes: ");
                    var note = Console.ReadLine();

                    clientList.Add(
                        new Client
                        {
                            Id = Id,
                            OpenDate = open,
                            ClosedDate = close,
                            IsActive = active,
                            Name = name ?? "John/Jane Doe",
                            Notes = note ?? "No note"

                        }
                    );
                }

                //read
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    clientList.ForEach(Console.WriteLine);
                }

                //update
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Which client would you like to update? Please enter their ID number");
                    clientList.ForEach(Console.WriteLine);
                    //reading in Id variable to fine
                    var update = int.Parse(Console.ReadLine() ?? "0");
                    //finding client to update
                    var clientUpdate = clientList.FirstOrDefault(c => c.Id == update);
                    

                    if (clientUpdate != null)
                    {
                        Console.WriteLine("What is the clients new OpenDate?");
                        clientUpdate.OpenDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("What is the clients new CloseDate");
                        clientUpdate.OpenDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("Is the client still active? yes or no");
                        var ac = Console.ReadLine();

                        if (ac.Equals("no", StringComparison.InvariantCultureIgnoreCase))
                        {
                            clientUpdate.IsActive = false;
                        }
                        else
                        {
                            clientUpdate.IsActive = true;
                        }
                        Console.WriteLine("What is clients new name?");
                        clientUpdate.Name = Console.ReadLine() ?? "John/Jane Doe";

                        Console.WriteLine("Any Notes for the clients?");
                        clientUpdate.Notes = Console.ReadLine() ?? "No note";
                    }
                }

                //delete
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Please enter the ID of which client you would like to delete?");
                    clientList.ForEach(Console.WriteLine);
                    var delete = int.Parse(Console.ReadLine() ?? "0");

                    var clientDelete = clientList.FirstOrDefault(c => c.Id == delete);
                    if (clientDelete != null)
                    {
                        clientList.Remove(clientDelete);
                    }
                }

                else if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }

        }
        static void ProjectMenu(List<Project> projectList, List<Client> clientList)
        {
            while (true)
            {
                Console.WriteLine("C. Create Project");
                Console.WriteLine("R. List Project");
                Console.WriteLine("U. Update Project");
                Console.WriteLine("D. Delete Project");
                Console.WriteLine("Q. Quit");

                var choice = Console.ReadLine() ?? string.Empty;

                //create
                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Id: ");
                    var id = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("Project OpenDate: ");
                    var open = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                    Console.WriteLine("Project ClosedDate: ");
                    var close = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                    Console.WriteLine("IsActive: true ");
                    var active = true;

                    Console.WriteLine("Shortname: ");
                    var shortname = Console.ReadLine();

                    Console.WriteLine("Longname: ");
                    var longname = Console.ReadLine();

                    Console.WriteLine("ClientID: ");
                    var clientid = int.Parse(Console.ReadLine() ?? "0");     
                    var selectedClient = clientList.FirstOrDefault(x => x.Id == clientid);

                    if (selectedClient != null)
                    {
                        projectList.Add(
                       new Project
                       {
                           Id = id,
                           OpenDate = open,
                           ClosedDate = close,
                           IsActive = active,
                           ShortName = shortname ?? "John/Jane Doe",
                           LongName = longname ?? "John/Jane Doe",
                           ClientId = selectedClient.Id

                       });

                    }
                    else
                    {
                        Console.WriteLine("w");
                    }


                   
                }

                //read
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    projectList.ForEach(Console.WriteLine);
                }

                //update
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Which project would you like to update? ");
                    projectList.ForEach(Console.WriteLine);
                    var update = int.Parse(Console.ReadLine() ?? "0");

                    var projectUpdate = projectList.FirstOrDefault(x => x.Id == update);
                    if (projectUpdate != null)
                    {
                        Console.WriteLine("What is projects new Open date?");
                        projectUpdate.OpenDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("What is the clients new CloseDate");
                        projectUpdate.ClosedDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("Is the client still active? yes or no");
                        var ac = Console.ReadLine();

                        if (ac.Equals("no", StringComparison.InvariantCultureIgnoreCase))
                        {
                            projectUpdate.IsActive = false;
                        }
                        else
                        {
                            projectUpdate.IsActive = true;
                        }

                        Console.WriteLine("What is projects new shortname?");
                        projectUpdate.ShortName = Console.ReadLine() ?? "John/Jane Doe";

                        Console.WriteLine("What is projects new longname?");
                        projectUpdate.LongName = Console.ReadLine() ?? "John/Jane Doe";

                        Console.WriteLine("What is the client ID with the project? ");
                        projectUpdate.ClientId = int.Parse(Console.ReadLine() ?? "0");
                    }
                }
                //delete
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Please enter the ID of the project you want to delete ");
                    projectList.ForEach(Console.WriteLine);
                    var delete = int.Parse(Console.ReadLine() ?? "0");

                    var projectDelete = projectList.FirstOrDefault(x => x.Id == delete);
                    if (projectDelete != null)
                    {
                        projectList.Remove(projectDelete);
                    }
                }
                else if (choice.Equals ("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }

            }
        }
    }
}
     
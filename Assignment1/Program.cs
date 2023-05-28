using Assignment1.Models;
using System;


namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Client> clientList = new List<Client>();
            List<Project> projectList = new List<Project>();

            while(true)
            {
                Console.WriteLine("Welcome to program! :) \n"  +
                    "A. ClientMenu \n" +
                    "B. ProjectMenu \n" +
                    "Q. Exit Program \n");

                var choice = Console.ReadLine();
                if (choice.Equals("A", StringComparison.InvariantCultureIgnoreCase))
                {
                    ClientMenu(clientList);
                }
                else if(choice.Equals("B", StringComparison.InvariantCultureIgnoreCase))
                {
                    ProjectMenu(projectList, clientList);
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
                    foreach (var client in clientList)
                    {
                    //clientList.ForEach(Console.WriteLine);
                    //Console.WriteLine("test");
                    Console.WriteLine("Id:" +client.Id);
                    Console.WriteLine("OpenDate:" + client.OpenDate);
                    Console.WriteLine("ClosedDate:" + client.ClosedDate);
                    Console.WriteLine("IsActive:" + client.IsActive);
                    Console.WriteLine("Name:" + client.Name);
                    Console.WriteLine("Notes:" + client.Notes + "\n");
                    
                    }
                }

                //update
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Which client would you like to update? Please enter their ID number");
                    //clientList.ForEach(Console.WriteLine);
                    foreach (var client in clientList)
                    {
                        
                        Console.WriteLine("Id:" + client.Id);
                        Console.WriteLine("OpenDate:" + client.OpenDate);
                        Console.WriteLine("ClosedDate:" + client.ClosedDate);
                        Console.WriteLine("IsActive:" + client.IsActive);
                        Console.WriteLine("Name:" + client.Name);
                        Console.WriteLine("Notes:" + client.Notes + "\n");

                    }
                    //reading in Id variable to find
                    var update = int.Parse(Console.ReadLine() ?? "0");
                    //finding client to update
                    var clientUpdate = clientList.FirstOrDefault(c => c.Id == update);
                    

                    if (clientUpdate != null)
                    {
                        Console.WriteLine("What is the clients new OpenDate?");
                        clientUpdate.OpenDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("What is the clients new CloseDate");
                        clientUpdate.ClosedDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

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
                    foreach (var client in clientList)
                    {
                        Console.WriteLine("Id:" + client.Id);
                        Console.WriteLine("OpenDate:" + client.OpenDate);
                        Console.WriteLine("ClosedDate:" + client.ClosedDate);
                        Console.WriteLine("IsActive:" + client.IsActive);
                        Console.WriteLine("Name:" + client.Name);
                        Console.WriteLine("Notes:" + client.Notes + "\n");

                    }
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
                        projectList.Add(
                       new Project
                       {
                           Id = id,
                           OpenDate = open,
                           ClosedDate = close,
                           IsActive = active,
                           ShortName = shortname ?? "John/Jane Doe",
                           LongName = longname ?? "John/Jane Doe",
                       });
                    }
                }

                //read
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    foreach (var project in projectList)
                    {
                        Console.WriteLine("Id:" + project.Id);
                        Console.WriteLine("OpenDate:" + project.OpenDate);
                        Console.WriteLine("ClosedDate:" + project.ClosedDate);
                        Console.WriteLine("IsActive:" + project.IsActive);
                        Console.WriteLine("ShortName:" + project.ShortName);
                        Console.WriteLine("LongName:" + project.LongName);
                        Console.WriteLine("ClientId:" + project.ClientId + "\n");

                    }
                }

                //update
               else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Which project would you like to update? ");
                    foreach (var project in projectList)
                    {
                        Console.WriteLine("Id:" + project.Id);
                        Console.WriteLine("OpenDate:" + project.OpenDate);
                        Console.WriteLine("ClosedDate:" + project.ClosedDate);
                        Console.WriteLine("IsActive:" + project.IsActive);
                        Console.WriteLine("ShortName:" + project.ShortName);
                        Console.WriteLine("LongName:" + project.LongName);
                        Console.WriteLine("ClientId:" + project.ClientId + "\n");
                    }
                    var update = int.Parse(Console.ReadLine() ?? "0");

                    var projectUpdate = projectList.FirstOrDefault(x => x.Id == update);
                    if (projectUpdate != null)
                    {
                        Console.WriteLine("What is projects new Open date?");
                        projectUpdate.OpenDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("What is the clients new CloseDate");
                        projectUpdate.ClosedDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                        Console.WriteLine("Is the project still active? yes or no");
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

                        Console.WriteLine("Would you like to Update the client ID? Yes or No");
                        var select = Console.ReadLine(); 

                        if (select.Equals( "yes", StringComparison.InvariantCultureIgnoreCase))
                        {
                            Console.WriteLine("What is the new Clients ID?");
                            var clientid = int.Parse(Console.ReadLine() ?? "0");
                            var selectedClient = clientList.FirstOrDefault(x => x.Id == clientid);
                            projectUpdate.ClientId = selectedClient.Id;
                        }
                      

                    }
                }
                //delete
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Please enter the ID of the project you want to delete ");
                    foreach (var project in projectList)
                    {
                        Console.WriteLine("Id:" + project.Id);
                        Console.WriteLine("OpenDate:" + project.OpenDate);
                        Console.WriteLine("ClosedDate:" + project.ClosedDate);
                        Console.WriteLine("IsActive:" + project.IsActive);
                        Console.WriteLine("ShortName:" + project.ShortName);
                        Console.WriteLine("LongName:" + project.LongName);
                        Console.WriteLine("ClientId:" + project.ClientId + "\n");
                    }
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
     
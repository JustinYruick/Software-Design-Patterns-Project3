using System;
using System.Collections.Generic;

namespace Assi3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Server> Servers = new List<Server>();
            Queue<Request> PendingRequests = new Queue<Request>();
            ServerQuery query = new ServerQuery();

            Console.WriteLine("Please enter a command.");
            string command = "";

            while(command != "quit") {
                string[] commandArgs = command.Split(":");
                Console.WriteLine();

                switch(commandArgs[0]) {
                    case "help":
                        Console.WriteLine("help\t\t\tDisplay this menu");
                        Console.WriteLine("createserver\t\tCreate a new server.");
                        Console.WriteLine("deleteserver:[id]\tDelete server #ID.");
                        Console.WriteLine("listservers\t\tList all servers.");
                        Console.WriteLine("new:[path]:[payload]\tCreate a new pending request.");
                        Console.WriteLine("dispatch\t\tSend a pending request to a server.");
                        Console.WriteLine("server:[id]\t\tHave server #ID execute its pending request and print the result.");
                        Console.WriteLine("quit\t\t\tQuit the application");
                        break;
                    case "createserver":
                        Server newServer = new Server();
                        Servers.Add(newServer);
                        Console.WriteLine("Created Server:" + (Servers.Count -1));
                        break;
                    case "deleteserver":
                        string sIndex = commandArgs[1];

                        try
                        {
                            int index = int.Parse(sIndex);
                            Servers.RemoveAt(index);
                            Console.WriteLine("Deleted Server:" + index);
                        }
                        catch(Exception err)
                        {
                            Console.WriteLine("Invalid input" + err.Message);
                        }
                        break;
                    case "listservers":
                        int x = 0;
                        foreach(Server server in Servers)
                        {
                            Console.WriteLine(x + "  Server");
                            x++;
                        }
                        break;
                    case "new":
                        if (commandArgs[1] == "/mul" || commandArgs[1] == "/mul/4" || commandArgs[1] == "/add")
                        {
                            try
                            {
                                Request newRequest = new Request(commandArgs[1], int.Parse(commandArgs[2]));
                                Console.WriteLine($"Created request with data {commandArgs[2]} going to {commandArgs[1]}");
                                PendingRequests.Enqueue(newRequest);
                            }
                            catch (Exception err)
                            {
                                Console.WriteLine("Invalid number input" + err.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                        break;
                    case "dispatch":
                        if(PendingRequests.Count == 0)
                        {
                            Console.WriteLine("No Pending Requests");
                            break;
                        }
                        else if(Servers.Count == 0)
                        {
                            Console.WriteLine("No Servers avaliable (521)");
                            break;
                        }
                        else
                        {
                            int count = 0;
                            bool foundserver = false;
                            foreach (Server server in Servers)
                            {
                                if(!server.Accept(query))
                                {
                                    server.takeRequest(PendingRequests.Dequeue());
                                    Console.WriteLine("Sent request to server: " + count);
                                    count++;
                                    foundserver = true;
                                    break;
                                }
                            }
                            if(foundserver == false)
                            {
                                Console.WriteLine("No Servers avaliable (521)");
                            }
                        }
                        break;
                    case "server":
                        int serverIndex = int.Parse(commandArgs[1]);
                        int result = 0;
                        if (Servers[serverIndex].Request != null)
                        {
                           result = Servers[serverIndex].executeRequest();
                            Console.WriteLine($"Path: {Servers[serverIndex].Request.Route}\nInput: {Servers[serverIndex].Request.Payload}\nResult: {result}");
                            Servers[int.Parse(commandArgs[1])].RemoveRequest();
                        }
                        else
                        {
                            Console.WriteLine("The is no Request on this server");
                        }
                        break;
                    default:
                        if(command != "") {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                }

                Console.WriteLine();
                command = Console.ReadLine();
            }
        }
    }
}

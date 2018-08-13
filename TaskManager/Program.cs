using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        static List<TaskModel> list = new List<TaskModel>();
        /// <summary>
        /// Menu with commands
        /// </summary>
        static void Main(string[] args)
        {
            TaskModel choice = new TaskModel();
            string command;
            do
            {
                ConsoleEx.WriteLine("List of avaiable commands:\n1. Add task\n2. Delete task\n3. Show tasks\n4. Save to file\n5. Load from file\n6. Exit", ConsoleColor.DarkYellow);
                command = Console.ReadLine().ToLower();
                if (command == "add" || command == "1")
                {
                    Console.Clear();
                    list.Add(choice.AddTask());
                    Console.ReadKey();
                    Console.Clear();

                }

                if (command == "delete" || command == "2")
                {
                    Console.Clear();
                    Console.Write("Which task do you want to delete? ");
                    choice.ShowTasks(list);
                    choice.DeleteTask(list);
                    Console.ReadKey();
                    Console.Clear();
                }

                if (command == "show" || command == "3")
                {
                    Console.Clear();
                    choice.ShowTasks(list);
                    Console.ReadKey();
                    Console.Clear();
                }

                if (command == "save" || command == "4")
                {
                    Console.Clear();
                    choice.SaveTasks(list);
                    Console.ReadKey();
                    Console.Clear();
                }

                if (command == "load" || command == "5")
                {
                    Console.Clear();
                    list=choice.LoadTasks();
                    Console.ReadKey();
                    Console.Clear();
                }




            } while (command != "exit" && command != "6");



        }
    }
}

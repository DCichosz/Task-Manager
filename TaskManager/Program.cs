using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        public static List<TaskModel> lista = new List<TaskModel>();
        /// <summary>
        /// Menu wyboru polecenia
        /// </summary>
        static void Main(string[] args)
        {
            TaskModel choice = new TaskModel();
            string command;
            do
            {
                ConsoleEx.WriteLine("Lista dostępnych komend to:\n1. Dodaj zadanie\n2. Usuń zadanie \n3. Wyświetl zadania\n4. Zapisz do pliku\n5. Wczytaj z pliku\n6. Wyjście", ConsoleColor.DarkYellow);
                command = Console.ReadLine().ToLower();
                if (command == "dodaj" || command == "1")
                {
                    Console.Clear();
                    lista.Add(choice.AddTask());
                    Console.ReadKey();
                    Console.Clear();

                }

                if (command == "usuń" || command == "usun" || command == "2")
                {
                    Console.Clear();
                    Console.Write("Które zadanie chcesz usunąć? ");
                    choice.ShowTasks(lista);
                    choice.DeleteTask(lista);
                    Console.ReadKey();
                    Console.Clear();
                }

                if (command == "wyświetl" || command == "3")
                {
                    Console.Clear();
                    choice.ShowTasks(lista);
                    Console.ReadKey();
                    Console.Clear();
                }

                if (command == "zapisz" || command == "4")
                {
                    Console.Clear();
                    choice.SaveTasks(lista);
                    Console.ReadKey();
                    Console.Clear();
                }

                if (command == "wczytaj" || command == "5")
                {
                    Console.Clear();
                    lista=choice.LoadTasks();
                    Console.ReadKey();
                    Console.Clear();
                }




            } while (command != "wyjście" && command != "6");



        }
    }
}

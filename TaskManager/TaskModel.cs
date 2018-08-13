using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace TaskManager
{
    public class TaskModel
    {
        public string Opis;
        public DateTime Start;
        public DateTime? Koniec;
        public bool Allday;
        public bool Important;

        public TaskModel(string opis, DateTime start, DateTime? koniec, bool allday, bool important)
        {
            Opis = opis;
            Start = start;
            Koniec = koniec;
            Allday = allday;
            Important = important;
        }

        public TaskModel()
        {

        }

        /// <summary>
        /// Dodanie zadania do modelu TaskModel
        /// </summary>
        /// <returns> zwrotka obiektu TaskModel </returns>
        public TaskModel AddTask()
        {
            bool validation = false;
            do
            {
                try
                {
                    ConsoleEx.WriteLine("Wpisz opis wydarzenia: ", ConsoleColor.Blue);
                    Opis = Console.ReadLine();
                    ConsoleEx.WriteLine("Wpisz datę rozpoczęcia(rok-miesiąc-dzień): ", ConsoleColor.Yellow);
                    Start = Convert.ToDateTime(Console.ReadLine());
                    ConsoleEx.WriteLine("Całodniowe? [tak/nie]", ConsoleColor.Cyan);
                    string allDay = Console.ReadLine();

                    if (allDay == "nie" || allDay == "")
                    {
                        Allday = false;
                        ConsoleEx.WriteLine("Wpisz datę zakończenia(rok-miesiąc-dzień", ConsoleColor.DarkYellow);
                        Koniec = Convert.ToDateTime(Console.ReadLine());
                    }

                    if (allDay == "tak")
                    {
                        Allday = true;
                        Koniec = null;
                    }

                    ConsoleEx.WriteLine("Priorytetowe? [tak/nie]", ConsoleColor.DarkRed);
                    string important = Console.ReadLine();
                    if (important == "nie" || important == "")
                    {
                        Important = false;
                    }
                    else
                    {
                        Important = true;
                    }

                    validation = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    validation = false;
                }

            } while (validation == false);

            TaskModel task = new TaskModel(Opis, Start, Koniec, Allday, Important);
            ConsoleEx.WriteLine("Pomyślnie dodano wpis", ConsoleColor.Green);
            return task;
        }
        /// <summary>
        /// Wywołanie w konsoli listy zadań
        /// </summary>
        /// <param name="list">Parametrem metody jest lista modelu TaskModel </param>
        public void ShowTasks(List<TaskModel> list)
        {
            try
            {
                int i = 0;
                foreach (var element in list)
                {
                    if (element.Allday == true)
                    {
                        ConsoleEx.Write(
                            $"{i + 1}. Opis: {element.Opis}, Data rozpoczęcia: {element.Start}, Całodniowe: Tak, ",
                            ConsoleColor.Magenta);
                    }
                    else
                    {
                        ConsoleEx.Write(
                            $"{i + 1}. Opis: {element.Opis}, Data rozpoczęcia: {element.Start}, Data zakończenia: {element.Koniec}, ",
                            ConsoleColor.Magenta);
                    }

                    if (element.Important == true)
                    {
                        ConsoleEx.Write("Ważne: Tak", ConsoleColor.Magenta);
                    }
                    else
                    {
                        ConsoleEx.Write("Ważne: Nie", ConsoleColor.Magenta);
                    }

                    Console.WriteLine();
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Usunięcie zadania z listy
        /// </summary>
        /// <param name="list"> lista zadań </param>
        public void DeleteTask(List<TaskModel> list)
        {
            try
            {
                int ind = int.Parse(Console.ReadLine());
                list.RemoveAt(ind - 1);
                ConsoleEx.WriteLine("Pomyślnie usunięto wpis", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Zapis zadań z listy do pliku
        /// </summary>
        /// <param name="list"> lista zadań </param>
        public void SaveTasks(List<TaskModel> list)
        {
            try
            {
                string file = "Data.csv";
                File.Delete(file);
                foreach (var element in list)
                {
                    string save =
                        $"{element.Opis};{element.Start.ToString()};{element.Koniec.ToString()};{element.Allday.ToString()};{element.Important.ToString()}\n";
                    File.AppendAllText(file, save);
                }

                ConsoleEx.WriteLine("Pomyslnie zapisano wpisy", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Ładowanie zadań z pliku do listy
        /// </summary>
        /// <returns> Zwrotka listy TaskModel </returns>
        public List<TaskModel> LoadTasks()
        {
            List<TaskModel> taskList = new List<TaskModel>();
            try
            {
                string path = "Data.csv";
                string[] fileTab = File.ReadAllLines(path);
                foreach (var element in fileTab)
                {
                    string[] taskInfo = element.Split(";");
                    Opis = taskInfo[0];
                    Start = Convert.ToDateTime(taskInfo[1]);
                    if (taskInfo[2] != "" && taskInfo[2] != null)
                    {
                        Koniec = Convert.ToDateTime(taskInfo[2]);
                        Allday = false;
                    }

                    Koniec = null;
                    Allday = true;
                    if (taskInfo[4] == "True")
                    {
                        Important = true;
                    }

                    if (taskInfo[4] == "False")
                    {
                        Important = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            TaskModel task = new TaskModel(Opis, Start, Koniec, Allday, Important);
            taskList.Add(task);
            ConsoleEx.WriteLine("Pomyślnie wczytano wpisy", ConsoleColor.Green);
            return taskList;


        }
    }
}

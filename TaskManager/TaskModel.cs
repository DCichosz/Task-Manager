using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace TaskManager
{
    public class TaskModel
    {
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool Allday { get; set; }
        public bool Important { get; set; }

        public TaskModel(string description, DateTime start, DateTime? end, bool allday, bool important)
        {
            Description = description;
            Start = start;
            End = end;
            Allday = allday;
            Important = important;
        }

        public TaskModel()
        {

        }

        /// <summary>
        /// Adding task to TaskModel
        /// </summary>
        /// <returns> TaskModel object </returns>
        public TaskModel AddTask()
        {
            bool validation = false;
            do
            {
                try
                {
                    ConsoleEx.WriteLine("Task's describtion: ", ConsoleColor.Blue);
                    Description = Console.ReadLine();
                    ConsoleEx.WriteLine("Start date(year-month-day): ", ConsoleColor.Yellow);
                    Start = Convert.ToDateTime(Console.ReadLine());
                    ConsoleEx.WriteLine("Allday? [yes/no]", ConsoleColor.Cyan);
                    string allDay = Console.ReadLine();

                    if (allDay == "no" || allDay == "")
                    {
                        Allday = false;
                        ConsoleEx.WriteLine("End date(year-month-day", ConsoleColor.DarkYellow);
                        End = Convert.ToDateTime(Console.ReadLine());
                    }

                    if (allDay == "yes")
                    {
                        Allday = true;
                        End = null;
                    }

                    ConsoleEx.WriteLine("Important? [yes/no]", ConsoleColor.DarkRed);
                    string important = Console.ReadLine();
                    if (important == "no" || important == "")
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

            TaskModel task = new TaskModel(Description, Start, End, Allday, Important);
            ConsoleEx.WriteLine("Successfully added", ConsoleColor.Green);
            return task;
        }
        /// <summary>
        /// Display task list in console
        /// </summary>
        /// <param name="list"> TaskModel list </param>
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
                            $"{i + 1}. Describtion: {element.Description}, Start date: {element.Start}, Allday: True, ",
                            ConsoleColor.Magenta);
                    }
                    else
                    {
                        ConsoleEx.Write(
                            $"{i + 1}. Describtion: {element.Description}, Start date: {element.Start}, End date: {element.End}, ",
                            ConsoleColor.Magenta);
                    }

                    if (element.Important == true)
                    {
                        ConsoleEx.Write("Important: Yes", ConsoleColor.Magenta);
                    }
                    else
                    {
                        ConsoleEx.Write("Important: No", ConsoleColor.Magenta);
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
        /// Delete task from list
        /// </summary>
        /// <param name="list"> task list </param>
        public void DeleteTask(List<TaskModel> list)
        {
            try
            {
                int ind = int.Parse(Console.ReadLine());
                list.RemoveAt(ind - 1);
                ConsoleEx.WriteLine("Successfully deleted", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Save task to list
        /// </summary>
        /// <param name="list"> task list </param>
        public void SaveTasks(List<TaskModel> list)
        {
            try
            {
                string file = "Data.csv";
                File.Delete(file);
                foreach (var element in list)
                {
                    string save =
                        $"{element.Description};{element.Start.ToString()};{element.End.ToString()};{element.Allday.ToString()};{element.Important.ToString()}\n";
                    File.AppendAllText(file, save);
                }

                ConsoleEx.WriteLine("Successfully saved", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Loading tasks to list
        /// </summary>
        /// <returns> TaskModel list </returns>
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
                    Description = taskInfo[0];
                    Start = Convert.ToDateTime(taskInfo[1]);
                    if (taskInfo[2] != "" && taskInfo[2] != null)
                    {
                        End = Convert.ToDateTime(taskInfo[2]);
                        Allday = false;
                    }

                    End = null;
                    Allday = true;
                    if (taskInfo[4] == "True")
                    {
                        Important = true;
                    }

                    if (taskInfo[4] == "False")
                    {
                        Important = false;
                    }
                    TaskModel task = new TaskModel(Description, Start, End, Allday, Important);
                    taskList.Add(task);
                }
                ConsoleEx.WriteLine("Successfully loaded", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return taskList;


        }
    }
}

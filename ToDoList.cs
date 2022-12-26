using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW_2_5
{
    public class To_do
    {
        public int Todo_ID { get; set; }
        public string Task { get; set; }
        public DateTime Date { get; set; }
        public string RepeatType { get; set; }

        public To_do(int Todo_ID, string Task, DateTime date, string RepeatType)
        {
            this.Todo_ID = Todo_ID;
            this.Task = Task;
            this.Date = date;
            this.RepeatType = RepeatType;
        }

        public static void Main()
        {
            Random rnd = new Random();
            int ID = rnd.Next(89);

            List<To_do> TD_Task = new List<To_do>();
            bool check = true;

            while (true)
            {
                Menu.StartMenu();

                int CommandChoice = 0;
                int TaskTypeChoice = 0;
                int TaskRepeatTypeChoice = 0;

                try
                {
                    CommandChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Logger.Console_Log_Error("ERROR: Only numbers");
                }



                switch (CommandChoice)
                {
                    case 1: // 1.Add Task
                        Logger.Console_Log_Info("Add Task:");

                        Menu.CommandChoice();
                        try
                        {
                            TaskTypeChoice = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Logger.Console_Log_Error("ERROR: Only numbers");
                        }



                        switch (TaskTypeChoice)
                        {
                            case 1: //add-item
                                Logger.Console_Log_Info("add-item:");
                                Menu.Header();
                                Console.Write("Enter Task: \n");

                                string message1 = Console.ReadLine();
                                string date1 = DateTime.Now.ToString("dd.MM.yyyy");
                                string RepeatType1 = "";

                                ID++;
                                TD_Task.Add(new To_do(ID, message1, DateTime.Parse(date1), RepeatType1));
                                Logger.Console_Log_Error("New Task created with ID = " + ID.ToString() + " " + message1);
                                Logger.File_Log("INFO: add-item Task Added");
                                break;

                            case 2: //add-reminder
                                Logger.Console_Log_Info("add-reminder:");
                                Menu.Header();
                                Console.Write("Enter Task: \n");
                                string message2 = Console.ReadLine();

                                Console.Write("Enter the Date: [dd.MM.yyyy]\n");
                                string date2 = Console.ReadLine();
                                string RepeatType2 = "";

                                ID++;
                                TD_Task.Add(new To_do(ID, message2, DateTime.Parse(date2), RepeatType2));
                                Logger.Console_Log_Error("New Task created with ID = " + ID.ToString() + " " + message2 + " " + date2);
                                Logger.File_Log("INFO: add-reminder Task Added");
                                break;

                            case 3: //add-reminder-rc
                                Logger.Console_Log_Info("add-reminder-rc:");
                                Menu.Header();
                                Console.Write("Enter Task: \n");
                                string message3 = Console.ReadLine();

                                Console.Write("Enter the Date: [dd.MM.yyyy]\n");
                                string date3 = Console.ReadLine();

                                Menu.RepeatTypeChoice();

                                string RepeatType3 = "";

                                try
                                {
                                    TaskRepeatTypeChoice = int.Parse(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Logger.Console_Log_Error("ERROR: Only numbers");
                                }

                                switch (TaskRepeatTypeChoice)
                                {
                                    case 1: // Day
                                        RepeatType3 = "Every Day";
                                        break;
                                    case 2: // Week
                                        RepeatType3 = "Every Week";
                                        break;
                                    case 3: // Mounth
                                        RepeatType3 = "Every Mounth";
                                        break;
                                    case 4: // Year
                                        RepeatType3 = "Every Year";
                                        break;
                                }

                                ID++;
                                TD_Task.Add(new To_do(ID, message3, DateTime.Parse(date3), RepeatType3));
                                Logger.Console_Log_Error("New Task created with ID = " + ID.ToString() + " " + message3 + " " + date3 + " " + RepeatType3);
                                Logger.File_Log("INFO: add-reminder-rc Task Added");
                                break;

                            default:
                                Logger.Console_Log_Error("Invalid choice!");
                                break;
                        }

                        break;

                    case 2: // 2.Delete Task
                        Logger.Console_Log_Info("Delete Task:");
                        Menu.Header();
                        Console.Write("Enter the Task ID:\n");
                        try
                        {
                            int T_ID = int.Parse(Console.ReadLine());
                            Menu.Footer();
                            for (int i = 0; i < TD_Task.Count; i++)
                            {
                                if (TD_Task[i].Todo_ID == T_ID)
                                {
                                    check = false;
                                    TD_Task.RemoveAll(e => e.Todo_ID == T_ID);
                                }
                            }
                            if (check)
                            {
                                Console.WriteLine("No Task Found");
                            }
                            else
                            {
                                Logger.Console_Log_Error("Task Deleted");
                                Logger.File_Log("INFO: Task " + T_ID + " Deleted");
                            }
                            Menu.Footer();
                            Console.Write("Press any key to continue:");
                            Console.ReadKey();

                        }
                        catch (Exception)
                        {
                            Logger.Console_Log_Error("ERROR: Only numbers");
                        }
                        break;

                    case 3: // 3.Get all
                        Logger.Console_Log_Info("Get all:");
                        Menu.Header();
                        Console.WriteLine("\t\tID \tDate\tTask\t\tRepeatType");

                        foreach (To_do x in TD_Task)
                        {
                            check = false;
                            Logger.Console_Log_Error("\t\t" + x.Todo_ID + "  " + x.Date.ToString("dd.MM.yyyy") + "\t" + x.Task + "\t\t" + x.RepeatType);
                        }
                        if (check)
                        {
                            Logger.Console_Log_Error("No Tasks Found");
                        }
                        Menu.Footer();
                        Console.Write("Press any key to continue:");
                        Console.ReadKey();
                        break;

                    case 4: // 4.Update Task.
                        Logger.Console_Log_Info("Update Task:");
                        Menu.Header();
                        Console.Write("\t\tEnter the Task ID:\n\t\t");
                        try
                        {
                            int T_ID = int.Parse(Console.ReadLine());
                            Menu.Footer();
                            for (int i = 0; i < TD_Task.Count; i++)
                            {
                                if (TD_Task[i].Todo_ID == T_ID)
                                {
                                    check = false;
                                    Console.Write("\n\t\tEnter Task.\n\t\t");
                                    string msg = Console.ReadLine();
                                    TD_Task[i].Task = msg;
                                    Logger.Console_Log_Error("Task Updated");
                                    Logger.File_Log("INFO: Task " + T_ID + " Updated");
                                }
                            }
                            if (check)
                            {
                                Console.WriteLine("No Task Found\n\n");
                            }
                            Menu.Footer();
                            Console.Write("Press any key to continue:");
                            Console.ReadKey();
                        }
                        catch (Exception)
                        {
                            Logger.Console_Log_Error("ERROR: Insert Only Intergers!");
                        }
                        break;

                    case 5: // 5.Exit.
                        Environment.Exit(0);
                        break;

                    default:
                        Logger.Console_Log_Error("Incorrect choice");
                        break;
                }
            }
        }
    }
}

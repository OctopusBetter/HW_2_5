using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_5
{
    internal class Menu
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + " TODO List:\n");
            Console.WriteLine("------------");
        }

        public static void Footer()
        {
            Console.WriteLine("------------");
        }


        public static void StartMenu()
        {
            Header();
            Console.WriteLine("1.Add Task.\n");
            Console.WriteLine("2.Delete Task.\n");
            Console.WriteLine("3.Get all Tasks.\n");
            Console.WriteLine("4.Update Task.\n");
            Console.WriteLine("5.Exit.");
            Footer();
            Console.WriteLine("Enter your choice: ");
        }

        public static void CommandChoice()
        {
            Header();
            Console.WriteLine("1.add-item\n");
            Console.WriteLine("2.add-reminder\n");
            Console.WriteLine("3.add-reminder-rc\n");
            Footer();
            Console.WriteLine("Enter your choice: ");
        }
        public static void RepeatTypeChoice()
        {
            Header();
            Console.WriteLine("\n1.Every Day");
            Console.WriteLine("2.Every Week");
            Console.WriteLine("3.Every Mounth");
            Console.WriteLine("3.Every Year");
            Footer();
            Console.Write("Enter Task Repeat Type: \n");
        }

    }
}

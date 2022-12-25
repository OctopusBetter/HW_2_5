using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace HW_2_5
{
    internal class Logger
    {
        public static void Console_Log_Error(String msg)
        {
            Console.WriteLine("\n\n" + msg + "\n\n");
            Menu.Footer();
            Console.ReadKey();
        }

        public static void Console_Log_Info(String msg)
        {
            Menu.Header();
            Console.WriteLine("\n\n" + msg + "\n\n");
            Menu.Footer();
            Console.Write("Press <any> key to continue:");
            Console.ReadKey();
        }




        public static void File_Log(String FileMsg)
        {
            string Path = @"T:\applog\";
            string FileName = DateTime.Now.ToString("dd.MM.yyyy-hh.mm.ss") + ".txt";
            string FullPath = Path + FileName;

            bool i = true;
            do
            {
                File.Create(FullPath);
                var files = new DirectoryInfo(Path).EnumerateFiles()
                .OrderByDescending(f => f.CreationTime)
                .Skip(3)
                .ToList();
                files.ForEach(f => f.Delete());

                i = false;
            }
            while (i);

            File.AppendAllTextAsync(FullPath, "\n" + FileMsg + " " + DateTime.Now);
        }

    }
}

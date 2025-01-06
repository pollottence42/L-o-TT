using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HtmlEditor
{
    internal class Program
    {
        public static string folderPath = @"C:\LOTT\SinGit\L-o-TT";

        static void Main(string[] args)
        {

            string[] htmlFiles = Directory.GetFiles(folderPath, "*.html");

            while (true)
                Choosing(htmlFiles);
            
        }

        public static void Choosing(string[] htmlFiles)
        {
            var puncts = new string[]
            {
                "Вывести список файлов",
                "Напечатать файл",
                "Вставить в файл",
                "Создать файл",
                "Скопировать файл",
                "Отправить на сервер"
            };

            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < puncts.Length; i++)
                Console.WriteLine("{0}) {1}", i, puncts[i]);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            var temp = int.Parse(Console.ReadLine());
            switch (temp)
            {
                case 0:
                    var n = 0;
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (string file in htmlFiles)
                        Console.WriteLine("{0}) {1}", n++, file);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 1:
                    var print = new Print();
                    print.Activator(htmlFiles);
                    break;

                case 2:
                    var insert = new Insert();
                    insert.Activator(htmlFiles);
                    break;

                case 3:
                    var create = new Create();
                    create.Activator();
                    break;

                case 4:
                    var copy = new Copy();
                    copy.Activator(htmlFiles);
                    break;

                case 5:
                    var git = new Git();
                    git.Activator();
                    break;

                default:
                    break;
            }
        }
    }
}

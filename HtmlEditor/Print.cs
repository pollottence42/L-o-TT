using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlEditor
{
    public class Print
    {
        public static void Activator(string[] htmlFiles)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var n = 0;

            foreach (string file in htmlFiles)
            {
                Console.WriteLine("{0}) {1}", n++, Path.GetFileName(file));
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Какой файл напечатать??    ");

            Console.ForegroundColor = ConsoleColor.Red;

            var number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            var text = File.ReadAllText(htmlFiles[number]);

            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine(text);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

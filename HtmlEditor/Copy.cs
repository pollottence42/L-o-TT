using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlEditor
{
    public class Copy
    {
        public static void Activator(string[] htmlFiles)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var n = 0;

            foreach (string file in htmlFiles)
            {
                Console.WriteLine(" {0}) {1}", n++, Path.GetFileName(file));
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("Какой файл скопировать??    ");
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            var text = File.ReadAllText(htmlFiles[number]);
            File.WriteAllText(Program.folderPath + "\\new.html", text);

            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine("Текст скопирован в \"new\"");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

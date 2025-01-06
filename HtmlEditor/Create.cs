using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlEditor
{
    public class Create
    {
        public void Activator()
        {
            var txt = "{0} + {1} : файл создан";

            Console.ForegroundColor = ConsoleColor.Red;

            var a = Console.ReadLine();
            var b = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(txt, a, b);

            var str = string.Format(txt, a, b);
            File.WriteAllText(Program.folderPath + "\\new.txt", str);
        }
    }
}

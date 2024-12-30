using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlEditor
{
    public class Insert
    {
        public static void Activator(string[] htmlFiles, string folderPath)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var n = 0;

            foreach (string file in htmlFiles)
            {
                Console.WriteLine(n++ + ") " + Path.GetFileName(file));
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Какой файл изменить??    ");

            Console.ForegroundColor = ConsoleColor.Red;

            var number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            var text = File.ReadAllText(htmlFiles[number]);
            var shablon = File.ReadAllText(folderPath + "\\shablon.txt");
            var index = text.IndexOf("<!--here-->");

            if (index == -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("В файл невозможно вставить блок\n");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Введите Название: ");

            Console.ForegroundColor = ConsoleColor.Red;

            var name = Console.ReadLine();

            var t = "";
            var first = "";
            while (t != "<li></li>\n")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                first += t;
                Console.Write("Введите строчку описания: ");

                Console.ForegroundColor = ConsoleColor.Red;

                t = "<li>" + Console.ReadLine() + "</li>\n";
            }

            t = "";
            var second = "";
            while (t != "<br>\n")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                second += t;
                Console.Write("Введите строчку текста: ");

                Console.ForegroundColor = ConsoleColor.Red;

                t = Console.ReadLine() + "<br>\n";
            }

            t = "";
            var img = "";
            var alt = "";
            var image = "";
            var check = 0;
            while (img != "image/.jpg")
            {
                image += t;

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Write("Введите название изображения: ");

                Console.ForegroundColor = ConsoleColor.Red;

                img = "image/" + Console.ReadLine() + ".jpg";

                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write("Введите описание изображения: ");

                Console.ForegroundColor = ConsoleColor.Red;

                alt = Console.ReadLine();
                if (check % 2 == 0)
                    t = string.Format("<img class=\"image\" src=\"{0}\" alt=\"{1}\" height=\"42%\" width=\"42%\">\r\n &nbsp;&nbsp;&nbsp;&nbsp;", img, alt);
                else
                    t = string.Format("<img class=\"image\" src=\"{0}\" alt=\"{1}\" height=\"42%\" width=\"42%\">\r\n <br>", img, alt);
                check++;
            }

            if (check == 2)
                image = string.Format("<img class=\"image\" src=\"{0}\" alt=\"{1}\" height=\"56%\" width=\"56%\">\r\n", img, alt);


            var insert = string.Format(shablon, name, first, second, image);

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("Подтвердить выкладывание??   ");

            Console.ForegroundColor = ConsoleColor.Red;

            var yes = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;

            if (index == -1 || (yes != "да" && yes != "Да" && yes != "ДА"))
            {
                Console.WriteLine("Эх ну ладно");
            }
            else
            {
                Console.WriteLine("Текст добавлен");
                var newtext = text.Insert(index + 11, insert);
                File.WriteAllText(htmlFiles[number], newtext);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

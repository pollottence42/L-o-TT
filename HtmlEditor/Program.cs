using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace HtmlEditor

{

    internal class Program
    {
        static string folderPath = @"C:\LOTT\SinGit\L-o-TT";

        static void Main(string[] args)
        {

            string[] htmlFiles = Directory.GetFiles(folderPath, "*.html");

            while (true)
                Choosing(htmlFiles);
            
        }

        public static void Choosing(string[] htmlFiles)
        {
            Console.WriteLine(" 1) Напечатать файл \n 2) Создать файл \n 3) Скопировать файл \n 4) Вставить в файл");
            var temp = int.Parse(Console.ReadLine());
            switch (temp)
            {
                case 1:
                    Print(htmlFiles);
                    break;

                case 2:
                    Make();
                    break;

                case 3:
                    Copy(htmlFiles);
                    break;

                case 4:
                    Ins(htmlFiles);
                    break;

                default:
                    break;
            }
        }

        public static void Make()
        {
            var txt = "{0} - {1} yep";
            var a = Console.ReadLine();
            var b = Console.ReadLine();
            Console.WriteLine(txt, a, b);
            var str = string.Format(txt, a, b);
            File.WriteAllText(folderPath + "\\new.txt", str);
        }

        public static void Copy(string[] htmlFiles)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var n = 0;

            foreach (string file in htmlFiles)
            {
                Console.WriteLine( " {0}) {1}", n++, Path.GetFileName(file));
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("Какой файл скопировать??    ");
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            var text = File.ReadAllText(htmlFiles[number]);
            File.WriteAllText(folderPath + "\\new.html", text);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Текст скопирован в \"new\" ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Print(string[] htmlFiles)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var n = 0;

            foreach (string file in htmlFiles)
            {
                Console.WriteLine(n++ + ") " + Path.GetFileName(file));
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("Какой файл напечатать??    ");
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            var text = File.ReadAllText(htmlFiles[number]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Ins(string[] htmlFiles)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var n = 0;

            foreach (string file in htmlFiles)
            {
                Console.WriteLine(n++ + ") " + Path.GetFileName(file));
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("Какой файл изменить??    ");
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            var text = File.ReadAllText(htmlFiles[number]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            var shablon = File.ReadAllText(folderPath + "\\shablon.txt");
            var index = text.IndexOf("<!--here-->");

            Console.Write("Введите Название: ");
            var name = Console.ReadLine();

            var t = "";
            var first = "";
            while (t != "<li></li>\n")
            {
                first += t;
                Console.WriteLine("Введите строчку описания:");
                t = "<li>" + Console.ReadLine() + "</li>\n";
            }

            t = "";
            var second = "";
            while (t != "<br>\n")
            {
                second += t;
                Console.WriteLine("Введите строчку текста:");
                t = Console.ReadLine() + "<br>\n";
            }

            t = "";
            var img = "";
            var alt = "";
            var image = "";
            while (img != folderPath + "//image//.jpg" )
            {
                image += t;
                Console.WriteLine("Введите название изображения:");
                img = folderPath + "//image//" + Console.ReadLine() + ".jpg";
                Console.WriteLine("Введите описание изображения:");
                alt = Console.ReadLine();
                t = string.Format("<img class=\"image\" src=\"{0}\" alt=\"{1}\" height=\"56%\" width=\"56%\">\r\n <br>", img, alt);
            }

            var insert = string.Format(shablon, name, first, second, image);
            
            Console.Write("Подтвердить выкладывание?? ")
            var yes = Console.ReadLine();

            if (index == -1 || (yes!= "да" && yes!= "Да" && yes!="ДА"))
                Console.WriteLine("Эх ну ладно");
            else
            {
                var newtext = text.Insert(index + 11, insert);
                File.WriteAllText(htmlFiles[number], newtext);
            }



            Console.WriteLine("Текст добавлен");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

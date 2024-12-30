using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace HtmlEditor
{
    public class Git
    {
        public static void Activator()
        {
            // Путь к папке с вашим git репозиторием
            var repoPath = @"C:\LOTT\SinGit\L-o-TT"; // Измените на нужный вам путь

            Console.ForegroundColor = ConsoleColor.Cyan;

            // Запрос сообщения коммита
            Console.Write("Введите сообщение для коммита: ");

            Console.ForegroundColor = ConsoleColor.Red;

            string commitMessage = Console.ReadLine();

            // Выполнение команд git
            RunGitCommand(repoPath, "add .");
            RunGitCommand(repoPath, $"commit -m \"{commitMessage}\"");
            RunGitCommand(repoPath, "push");
        }

        public static void RunGitCommand(string workingDirectory, string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = command,
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();

                // Читаем выходные данные и ошибки
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                // Выводим результат в консоль
                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine(output);
                }
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Ошибка: " + error);
                }
            }
        }
    }
}

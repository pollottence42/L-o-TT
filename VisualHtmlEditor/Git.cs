using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualHtmlEditor
{
    public partial class Git : Form
    {
        public Git()
        {
            InitializeComponent();
            this.BackColor = Form1.Color;
        }

        private void add_Click(object sender, EventArgs e)
        {
            Activator("add .");
        }

        private void commit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Имя коммита: " + "\"" + textBox1.Text + "\"", "Вы уверены", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Commit("commit -m " + "\"" + textBox1.Text + "\"");
        }

        private void Commit (string command)
        {
            Activator(command);
        }

        private void push_Click(object sender, EventArgs e)
        {
            Activator("push");
        }

        public void Activator(string command)
        {
            // Путь к папке с вашим git репозиторием
            var repoPath = @"C:\LOTT\SinGit\L-o-TT"; // Измените на нужный вам 

            // Выполнение команд git
            RunGitCommand(repoPath, command);
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
                    MessageBox.Show("Успех");
                }
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Провалено успешно: " + error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            form1.Show();
        }
    }
}
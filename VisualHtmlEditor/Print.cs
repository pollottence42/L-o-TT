using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace VisualHtmlEditor
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
            this.BackColor = Form1.Color;
            text.BackColor = Form1.Color;
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog
            {
                Title = "Файл страницы",
                Filter = "Страницы сайта |*.html",
                InitialDirectory = @"C:\LOTT\SinGit\L-o-TT"
            };

            if (file.ShowDialog() == DialogResult.OK)
            {
                var filename = file.FileName;
                fileName.Text = filename;

                var code = File.ReadAllText(filename);
                text.Text = code;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            var form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var path = fileName.Text;

            if (!File.Exists(path))
            {
                MessageBox.Show($"Файл не найден: {path}");
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла: {ex.Message}");
            }
        }
    }
}

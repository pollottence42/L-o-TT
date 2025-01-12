using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualHtmlEditor
{
    public partial class Form1 : Form
    {
        public static System.Drawing.Color Color = System.Drawing.Color.PowderBlue;

        public static string FolderPath = @"C:\LOTT\SinGit\L-o-TT";

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Coral;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Coral;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.DarkSlateBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkSlateBlue;
            button2.ForeColor = Color.White;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Maroon;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Maroon;
            button3.ForeColor = Color.White;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
            button4.ForeColor = Color.IndianRed;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.IndianRed;
            button4.ForeColor = Color.White;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
            button5.ForeColor = Color.LightSeaGreen;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.LightSeaGreen;
            button5.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] htmlFiles = Directory.GetFiles(FolderPath, "*.html");
            var text = "Список файлов:" + Environment.NewLine + Environment.NewLine;
            foreach (var file in htmlFiles)
                text += Path.GetFileName(file) + Environment.NewLine + Environment.NewLine;

            var files = new Files(text);
            files.ShowDialog();
        }
    }
}

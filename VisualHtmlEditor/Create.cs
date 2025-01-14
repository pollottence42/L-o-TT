using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualHtmlEditor
{
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
            this.BackColor = Form1.Color;
            textBox1.BackColor = Form1.Color;
            textBox3.BackColor = Form1.Color;
            textBox5.BackColor = Form1.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileName = textBox2.Text + ".html";
            var title = textBox4.Text;
            var top = textBox6.Text;

            var path = @"C:\LOTT\SinGit\L-o-TT\";

            var shablon = File.ReadAllText(path + "newShablon.txt");

            var newFile = string.Format(shablon, title, top);

            var question = string.Format("Вы создаёте страницу с названием файла {0}, названием страницы {1}, заголовком {2}",
                                        fileName, title, top);

            var dialogResult = MessageBox.Show(question, "Уверены??", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
                File.WriteAllText(path + fileName, newFile);
        }
    }
}

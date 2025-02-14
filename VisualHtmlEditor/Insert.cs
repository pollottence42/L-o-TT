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
    public partial class Insert : Form
    {
        public Insert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\LOTT\\SinGit\\L-o-TT\\image";
                openFileDialog.Filter = "Изображения (*.jpg; *.png)|*.jpg; *.png"; 
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string[] filePaths = openFileDialog.FileNames;

                    MessageBox.Show("Выбраны файлы:\n" + string.Join("\n", filePaths));

                    var text = "";

                    foreach (var file in filePaths)
                        text += file + Environment.NewLine;
                    Images.Text = text;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\LOTT\\SinGit\\L-o-TT";
                openFileDialog.Filter = "Страницы сайтов (*.html)|*.html";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string[] filePaths = openFileDialog.FileNames;

                    MessageBox.Show("Выбран файл:\n" + string.Join("\n", filePaths));

                    var text = "";

                    foreach (var file in filePaths)
                        text += file + Environment.NewLine;
                    FileName.Text = text;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var fileName = FileName.Text.TrimEnd();
            var name = TextName.Text.TrimEnd();
            var text = Text.Text.TrimEnd();
            var dopText = TextDop.Text.TrimEnd();
            var images = Images.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var shablon = File.ReadAllText("C:\\LOTT\\SinGit\\L-o-TT\\shablon.txt");

            var textSh = "";
            foreach (var line in text.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                textSh += "<li>" + line + "</li\n>";
            }

            var dopTextSh = "";
            foreach (var line in dopText.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                dopTextSh += line + "<br>\n";
            }

            var imagesSh = "";
            var check = 0;

            if (images.Length <= 1 || images == null)
                imagesSh = "";
            else if (images.Length != 2)
            {
                foreach (var image in images)
                {
                    var img = "image\\" + Path.GetFileName(image);
                    if (img.Contains("."))
                    {
                        if (check % 2 == 0)
                            imagesSh += string.Format("<img class=\"image\" src=\"{0}\" height=\"42%\" width=\"42%\">\r\n &nbsp;&nbsp;&nbsp;&nbsp; \n", img);
                        else
                            imagesSh += string.Format("<img class=\"image\" src=\"{0}\" height=\"42%\" width=\"42%\">\r\n <br>\n", img);
                        check++;
                    }
                }
            }
            else
                imagesSh = string.Format("<img class=\"image\" src=\"{0}\" height=\"56%\" width=\"56%\">\r\n", images[0]);

            var insert = string.Format(shablon, name, textSh, dopTextSh, imagesSh);

            DialogResult dialogResult = MessageBox.Show("Сохраняем файл: уверен??", "Вопрос" , MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes && !string.IsNullOrEmpty(fileName))
            {
                var past = File.ReadAllText(fileName);
                var index = past.IndexOf("<!--here-->");
                past = past.Insert(index + 11, insert);
                File.WriteAllText(fileName, past);
            }
        }
    }
}

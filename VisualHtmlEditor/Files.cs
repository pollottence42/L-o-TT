using System;
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
    public partial class Files : Form
    {
        public Files(string text)
        {
            InitializeComponent();
            this.BackColor = Form1.Color;

            textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            form1.Show();
        }
    }
}

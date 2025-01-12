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
    }
}

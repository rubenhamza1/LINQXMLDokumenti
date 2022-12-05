using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQXMLDocs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            formUnos Unos = new formUnos();
            Unos.Show();
        }
    }
}

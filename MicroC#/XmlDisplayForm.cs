using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroC_
{
    public partial class XmlDisplayForm : Form
    {
        public XmlDisplayForm(string xmlContent)
        {
            InitializeComponent();

            // Remplissez le contenu du contrôle TextBox avec le contenu XML
            textBoxXmlContent.Text = xmlContent;
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxXmlContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Form1.Som==null)
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                EtudiantForm etudiantForm = new EtudiantForm();
                etudiantForm.Show();
                this.Hide();
               
            }
        }
    }
}

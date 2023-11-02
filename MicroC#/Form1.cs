using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MicroC_
{
    public partial class Form1 : Form
    {
        public static string Som=null;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string som = login.Text;
            string password = pass.Text;
            Som = som;

            // Charger la base de données XML
            XDocument xmlDoc = XDocument.Load("C:\\Users\\XPS\\source\\repos\\SW\\SW\\XMLFile1.xml");

            // Vérifier si les informations d'identification correspondent à un administrateur
            bool isAdmin = xmlDoc.Descendants("Admin")
                .Any(admin =>
                    (string)admin.Attribute("SOM") == som &&
                    (string)admin.Attribute("Password") == password);
            bool isEtudiant = xmlDoc.Descendants("Etudiant")
                .Any(etudiant =>
                    (string)etudiant.Attribute("SOM") == som &&
                    (string)etudiant.Attribute("password") == password);
                
            if (isAdmin)
            {
                // Rediriger vers l'interface administrateur
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
            }
            else if (isEtudiant)
            {
                // Rediriger vers l'interface étudiant
                Information etudiant = new Information();
                etudiant.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Unknown user ID");

            }

           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void login_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

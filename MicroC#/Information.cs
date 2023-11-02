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
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
            AfficherInformationsEtudiant(Form1.Som);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AfficherInformationsEtudiant(string somConnecte)
        {
            // Chargez le fichier XML
            XDocument xmlDoc = XDocument.Load("C:\\Users\\XPS\\source\\repos\\SW\\SW\\XMLFile1.xml");

            // Recherchez l'étudiant avec le SOM connecté
            var etudiant = xmlDoc.Descendants("Etudiant")
                .FirstOrDefault(e => e.Attribute("SOM")?.Value == somConnecte);

            if (etudiant != null)
            {
                // Liste des attributs à afficher
                string[] attributs = { "Nom", "Prenom", "Apogee", "CNE", "CIN", "DateN", "sexe" };

                // Effacez le contenu précédent du TableLayoutPanel
                tableLayoutPanel1.Controls.Clear();

                // Parcourez les attributs et ajoutez-les au TableLayoutPanel
                for (int i = 0; i < attributs.Length; i++)
                {
                    string attribut = attributs[i];
                    var valeur = etudiant.Attribute(attribut)?.Value;

                    if (!string.IsNullOrEmpty(valeur))
                    {
                        // Créez des labels pour le libellé et la valeur
                        Label labelLibelle = new Label();
                        labelLibelle.Text = attribut ;
                        labelLibelle.TextAlign = ContentAlignment.MiddleRight;

                        Label labelDonnee = new Label();
                        labelDonnee.Text = valeur;
                        labelDonnee.TextAlign = ContentAlignment.MiddleLeft;
                        labelDonnee.AutoSize = true;

                        // Ajoutez ces labels au TableLayoutPanel dans les deux colonnes
                        if (attribut == "DateN")
                            labelLibelle.Text = "Date de naissance";
                        tableLayoutPanel1.Controls.Add(labelLibelle, 0, i);
                        tableLayoutPanel1.Controls.Add(labelDonnee, 1, i);
                    }
                }
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
            EtudiantForm etudiantForm = new EtudiantForm();
            etudiantForm.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            Form.Show();
            this.Hide();
        }

        private void Information_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

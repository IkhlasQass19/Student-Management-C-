using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MicroC_
{
    public partial class AdminForm : Form
    {
        private XDocument xmlData; // Stockez votre document XML ici
        public AdminForm()
        {
            InitializeComponent();
            xmlData = XDocument.Load("C:\\Users\\XPS\\source\\repos\\SW\\SW\\XMLFile1.xml");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            // Obtenez le semestre sélectionné dans comboBox1
            string selectedSemester =sem.SelectedItem.ToString();

            // Effacez les éléments précédents dans mod
            mod.Items.Clear();

            // Remplissez mod avec les modules correspondant au semestre sélectionné
            if (selectedSemester == "Semestre 1")
            {
                mod.Items.Add("Intelligence Artificiel");
                mod.Items.Add("Bases de Donnees Avancee");
                mod.Items.Add("Cryptographie"); 
                mod.Items.Add("JEE");
                mod.Items.Add("Nouvelles Technologie IP");
                mod.Items.Add("Anglais scientifique");
            }
            else if (selectedSemester == "Semestre 2")
            {
                mod.Items.Add("Genie logicielle");
                mod.Items.Add("Moteurs de Recherche");
                mod.Items.Add("Datawarehousee");
                mod.Items.Add("Datamining");
                mod.Items.Add("Conceptions et Application repartie");
                mod.Items.Add("Anglais scientifique");
            }
            else if (selectedSemester == "Semestre 3")
            {
                mod.Items.Add("Algorithmique Parallele");
                mod.Items.Add("Services Web");
                mod.Items.Add("Gestion de Projets");
                mod.Items.Add("Securite Informatique");
                mod.Items.Add("Ingenierie Linguistique");
                mod.Items.Add("Traitement d'Images");
            }
            else
            {
                mod.Items.Add("Stage");
            }*/
            string selectedSemester = sem.SelectedItem.ToString();

            // Code pour peupler comboBox2 avec les modules du semestre
            var modules = xmlData.Descendants("Module")
                .Where(m => m.Attribute("semestre").Value == selectedSemester)
                .Select(m => m.Attribute("intitule").Value);

            mod.Items.Clear();
            mod.Items.AddRange(modules.ToArray());
        }

        /*   private void mod_SelectedIndexChanged(object sender, EventArgs e)
           {
               string selectedModule = mod.SelectedItem.ToString();
               string id_module = xmlData.Descendants("Module")
                   .Where(m => m.Attribute("intitule").Value == selectedModule)
                   .Select(m => m.Attribute("Id_module").Value)
                   .FirstOrDefault(); // Utilisez FirstOrDefault pour obtenir la première correspondance

               MessageBox.Show(id_module);
              // Code pour extraire les notes des étudiants pour le module sélectionné
              var notes = xmlData.Descendants("Note")
                   .Where(n => n.Attribute("Id_module").Value == id_module)
                   .Select(n => new
                   {
                       CNE = n.Attribute("CNE").Value,
                       Note = n.Attribute("note").Value
                   });

               // Afficher les notes dans un format lisible (par exemple, MessageBox)
               string notesText = "Notes pour le module " + selectedModule + " :\n\n";
               foreach (var note in notes)
               {
                   notesText += "CNE : " + note.CNE + ", Note : " + note.Note + "\n";
                   MessageBox.Show("CNE : " + note.CNE + ", Note : " + note.Note);
               }

               MessageBox.Show(notesText, "Notes des étudiants", MessageBoxButtons.OK);
           }
        private void mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedModule = mod.SelectedItem.ToString();
            string id_module = xmlData.Descendants("Module")
                .Where(m => m.Attribute("intitule").Value == selectedModule)
                .Select(m => m.Attribute("Id_module").Value)
                .FirstOrDefault();

            if (id_module != null)
            {
                // Code pour extraire les notes des étudiants pour le module sélectionné
                var notes = xmlData.Descendants("Note")
                    .Where(n => n.Attribute("Id_module").Value == id_module)
                    .Select(n => new
                    {
                        CNE = n.Attribute("CNE").Value,
                        Note = n.Attribute("note").Value
                    });

                // Effacez le tableau précédent
                tableLayoutPanel1.Controls.Clear();

                // Créez une ligne d'en-tête avec les titres
                tableLayoutPanel1.Controls.Add(new Label() { Text = "CNE", TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Nom", TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Prénom", TextAlign = ContentAlignment.MiddleCenter }, 2, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Note", TextAlign = ContentAlignment.MiddleCenter }, 3, 0);

                int row = 1;
                foreach (var note in notes)
                {
                    tableLayoutPanel1.Controls.Add(new Label() { Text = note.CNE, TextAlign = ContentAlignment.MiddleCenter }, 0, row);
                    tableLayoutPanel1.Controls.Add(new Label() { Text = xmlData.Descendants("Etudiant").First(eventArgs => eventArgs.Attribute("CNE").Value == note.CNE).Attribute("Nom").Value, TextAlign = ContentAlignment.MiddleCenter }, 1, row);
                    tableLayoutPanel1.Controls.Add(new Label() { Text = xmlData.Descendants("Etudiant").First(eventArgs => eventArgs.Attribute("CNE").Value == note.CNE).Attribute("Prenom").Value, TextAlign = ContentAlignment.MiddleCenter }, 2, row);
                    tableLayoutPanel1.Controls.Add(new Label() { Text = note.Note, TextAlign = ContentAlignment.MiddleCenter }, 3, row);

                    row++;
                }
            }
        }

*/
        private void mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedModule = mod.SelectedItem.ToString();
            string id_module = xmlData.Descendants("Module")
                .Where(m => m.Attribute("intitule").Value == selectedModule)
                .Select(m => m.Attribute("Id_module").Value)
                .FirstOrDefault();

            if (id_module != null)
            {
                // Code pour extraire les notes des étudiants pour le module sélectionné
                var notes = xmlData.Descendants("Note")
                    .Where(n => n.Attribute("Id_module").Value == id_module)
                    .Select(n => new
                    {
                        CNE = n.Attribute("CNE").Value,
                        Note = n.Attribute("note").Value
                    });

                // Effacez le tableau précédent
                tableLayoutPanel1.Controls.Clear();

                // Créez une ligne d'en-tête avec les titres
                tableLayoutPanel1.Controls.Add(new Label() { Text = "CNE", TextAlign = ContentAlignment.MiddleCenter ,AutoSize=true }, 0, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Nom", TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 1, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Prénom", TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 2, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Note", TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 3, 0);


                int row = 1;
                foreach (var note in notes)
                {

                    tableLayoutPanel1.Controls.Add(new Label() { Text = note.CNE, TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 0, row);
                    string nom = xmlData.Descendants("Etudiant")
                        .Where(etudiant => etudiant.Attribute("CNE").Value == note.CNE)
                        .Select(etudiant => etudiant.Attribute("Nom").Value)
                        .FirstOrDefault();
                    tableLayoutPanel1.Controls.Add(new Label() { Text = nom, TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 1, row);
                    string prenom = xmlData.Descendants("Etudiant")
                        .Where(etudiant => etudiant.Attribute("CNE").Value == note.CNE)
                        .Select(etudiant => etudiant.Attribute("Prenom").Value)
                        .FirstOrDefault();
                    tableLayoutPanel1.Controls.Add(new Label() { Text = prenom, TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 2, row);
                    tableLayoutPanel1.Controls.Add(new Label() { Text = note.Note, TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 3, row);

                    row++;
                }
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void XML_Click(object sender, EventArgs e)
        {
            Form1.Som = null;
            string selectedModule = mod.SelectedItem.ToString();
            string id_module = xmlData.Descendants("Module")
                .Where(m => m.Attribute("intitule").Value == selectedModule)
                .Select(m => m.Attribute("Id_module").Value)
                .FirstOrDefault();

            if (id_module != null)
            {
                // Créez un document XML pour stocker les données
                XDocument xmlDoc = new XDocument(
                    new XElement("ModuleNotes")
                );

                // Code pour extraire les notes des étudiants pour le module sélectionné
                var notes = xmlData.Descendants("Note")
                    .Where(n => n.Attribute("Id_module").Value == id_module)
                    .Select(n => new
                    {
                        CNE = n.Attribute("CNE").Value,
                        Note = n.Attribute("note").Value
                    });

                foreach (var note in notes)
                {
                    string cne = note.CNE;
                    string nom = xmlData.Descendants("Etudiant")
                        .Where(etudiant => etudiant.Attribute("CNE").Value == note.CNE)
                        .Select(etudiant => etudiant.Attribute("Nom").Value)
                        .FirstOrDefault();
                    string prenom = xmlData.Descendants("Etudiant")
                        .Where(etudiant => etudiant.Attribute("CNE").Value == note.CNE)
                        .Select(etudiant => etudiant.Attribute("Prenom").Value)
                        .FirstOrDefault();
                    string noteValue = note.Note;

                    // Ajoutez les données au document XML
                    xmlDoc.Root.Add(
                        new XElement("Etudiant",
                            new XAttribute("CNE", cne),
                            new XAttribute("Nom", nom),
                            new XAttribute("Prenom", prenom),
                            new XAttribute("Note", noteValue)
                        )
                    );
                }

                // Pour afficher le document XML dans un TextBox (facultatif)
                string xmlString = xmlDoc.ToString();
                // textBoxXML.Text = xmlString;

                // Créez une nouvelle fenêtre pour afficher le document XML sauvegardé
                using (XmlDisplayForm displayForm = new XmlDisplayForm(xmlString))
                {
                    displayForm.ShowDialog();
                    this.Hide();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SemAdmin semAdmin = new SemAdmin();
            semAdmin.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            Form.Show();
            this.Hide();
        }
    }
}

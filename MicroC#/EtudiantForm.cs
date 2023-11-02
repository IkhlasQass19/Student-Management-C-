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

namespace MicroC_
{
    public partial class EtudiantForm : Form
    {
        private XDocument xmlData;
        public EtudiantForm()
        {
            InitializeComponent();
            xmlData = XDocument.Load("C:\\Users\\XPS\\source\\repos\\SW\\SW\\XMLFile1.xml");
            tableLayoutPanel1.Visible = false;
        }

        private void EtudiantForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        /*
      
        private void LoadStudentGrades(string cne, string semester)
        {
            // Effacez le tableau précédent
            tableLayoutPanel1.Controls.Clear();
            // Créez une ligne d'en-tête avec les titres de colonnes
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Module", TextAlign = ContentAlignment.MiddleCenter , AutoSize = true}, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Note (Session O)", TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Note (Session R)", TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 2, 0);

            // Récupérez les modules pour le semestre sélectionné
            var modules = xmlData.Descendants("Module")
                .Where(m => m.Attribute("semestre").Value == semester)
                .Select(m => new
                {
                    Id_module = m.Attribute("Id_module").Value,
                    Intitule = m.Attribute("intitule").Value
                });

            int row = 1;
            foreach (var module in modules)
            {
                
                // Récupérez la note pour la session "o" (ordinaire)
                var noteO = xmlData.Descendants("Note")
                    .FirstOrDefault(n => n.Attribute("CNE").Value == cne && n.Attribute("Id_module").Value == module.Id_module && n.Attribute("session").Value == "o");

                // Récupérez la note pour la session "r" (rattrapage)
                var noteR = xmlData.Descendants("Note")
                    .FirstOrDefault(n => n.Attribute("CNE").Value == cne && n.Attribute("Id_module").Value == module.Id_module && n.Attribute("session").Value == "r");
    

                tableLayoutPanel1.Controls.Add(new Label() { Text = module.Intitule, TextAlign = ContentAlignment.MiddleCenter }, 0, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = noteO?.Attribute("note").Value ?? "N/A", TextAlign = ContentAlignment.MiddleCenter }, 1, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = noteR?.Attribute("note").Value ?? "N/A", TextAlign = ContentAlignment.MiddleCenter }, 2, row);

                row++;
            }
        }*/

        private void LoadStudentGrades(string cne, string semester)
        {
           
            // Effacez le tableau précédent
            tableLayoutPanel1.Controls.Clear();

            // Créez une ligne d'en-tête avec les titres de colonnes
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Module", TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Note (Session O)", TextAlign = ContentAlignment.MiddleCenter , AutoSize = true }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Note (Session R)", TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, 2, 0);

            // Récupérez les modules pour le semestre sélectionné
            var modules = xmlData.Descendants("Module")
                .Where(m => m.Attribute("semestre").Value == semester)
                .Select(m => new
                {
                    Id_module = m.Attribute("Id_module").Value,
                    Intitule = m.Attribute("intitule").Value
                });

            int row = 1;
            foreach (var module in modules)
            {
                Label labelModule = new Label();
                labelModule.Text = module.Intitule;
                labelModule.TextAlign = ContentAlignment.MiddleCenter;
                labelModule.AutoSize = true; // Cette ligne ajuste automatiquement la largeur de la cellule

                tableLayoutPanel1.Controls.Add(labelModule, 0, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = GetGrade(cne, module.Id_module, "o"), TextAlign = ContentAlignment.MiddleCenter }, 1, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = GetGrade(cne, module.Id_module, "r"), TextAlign = ContentAlignment.MiddleCenter }, 2, row);

                row++;
            }
          
        }

        private string GetGrade(string cne, string id_module, string session)
        {
            // Code pour récupérer la note en fonction de CNE, id_module et session (o ou r)
            var note = xmlData.Descendants("Note")
                .FirstOrDefault(n => n.Attribute("CNE").Value == cne && n.Attribute("Id_module").Value == id_module && n.Attribute("session").Value == session);

            return note?.Attribute("note").Value ?? "N/A";
        }

        private void semestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            string selectedSemestre = semestre.SelectedItem.ToString(); // Obtenez le semestre sélectionné (S1, S2 ou S3)
            // Chargez xmlData à partir de votre fichier XML (assurez-vous de le charger correctement)

            string som = Form1.Som;
            LoadStudentGrades(som, selectedSemestre);
        }
        private void semestre_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedSemestre = semestre.SelectedItem.ToString(); // Obtenez le semestre sélectionné (S1, S2 ou S3)
            XmlDocument xmlDoc = new XmlDocument();
            String som = Form1.Som;
            xmlDoc.Load("C:\\Users\\XPS\\source\\repos\\SW\\SW\\XMLFile1.xml"); // Assurez-vous de spécifier le chemin correct vers votre fichier XML

            // Rechercher l'étudiant avec le SOM correspondant
            XmlNode etudiantNode = xmlDoc.SelectSingleNode($"/BDSW/Etudiants/Etudiant[@SOM='{som}']");

            string selectedCNE = etudiantNode.Attributes["CNE"].Value;

            string selectedSemester = semestre.SelectedItem.ToString();

            LoadStudentGrades(selectedCNE, selectedSemester);
            tableLayoutPanel1.Visible = true;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Rediriger vers l'interface étudiant
            Information etudiant = new Information();
            etudiant.Show();
            this.Hide();
        }

        private void XML_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            String som = Form1.Som;
            xmlDoc.Load("C:\\Users\\XPS\\source\\repos\\SW\\SW\\XMLFile1.xml"); // Assurez-vous de spécifier le chemin correct vers votre fichier XML

            // Rechercher l'étudiant avec le SOM correspondant
            XmlNode etudiantNode = xmlDoc.SelectSingleNode($"/BDSW/Etudiants/Etudiant[@SOM='{som}']");

            string selectedCNE = etudiantNode.Attributes["CNE"].Value;

            string selectedSemester = semestre.SelectedItem.ToString();

            GenerateStudentGradesXML(selectedCNE, selectedSemester);
        }
        private void GenerateStudentGradesXML(string cne, string semester)
        {
            // Créez un document XML pour stocker les données
            XDocument xmlDoc = new XDocument(
                new XElement("StudentGrades")
            );

            // Code pour extraire les modules du semestre choisi
            var modulesForSemester = xmlData.Descendants("Module")
                .Where(module => module.Attribute("semestre") != null && module.Attribute("semestre").Value == semester)
                .Select(module => new
                {
                    Id_module = module.Attribute("Id_module").Value,
                    Intitule = module.Attribute("intitule").Value
                });

            foreach (var module in modulesForSemester)
            {
                string moduleId = module.Id_module;
                string moduleTitle = module.Intitule;

                // Recherchez la note de l'étudiant pour le module, le semestre et la session "o" (ordinaire)
                var studentGradeO = xmlData.Descendants("Note")
                    .FirstOrDefault(note =>
                        note.Attribute("CNE").Value == cne &&
                        note.Attribute("Id_module").Value == moduleId &&
                        note.Attribute("session").Value == "o");

                // Recherchez la note de l'étudiant pour le module, le semestre et la session "r" (rattrapage)
                var studentGradeR = xmlData.Descendants("Note")
                    .FirstOrDefault(note =>
                        note.Attribute("CNE").Value == cne &&
                        note.Attribute("Id_module").Value == moduleId &&
                        note.Attribute("session").Value == "r");

                // Ajoutez les données au document XML, même si elles sont nulles
                xmlDoc.Root.Add(
                    new XElement("ModuleGrades",
                        new XAttribute("Module", moduleTitle),
                        new XAttribute("GradeO", studentGradeO?.Attribute("note").Value ?? "N/A"),
                        new XAttribute("GradeR", studentGradeR?.Attribute("note").Value ?? "N/A")
                    )
                );
            }

            // Affichez le document XML dans une nouvelle fenêtre ou utilisez une TextBox pour afficher le contenu XML
            string xmlContent = xmlDoc.ToString();

            // Créez une nouvelle fenêtre ou utilisez une TextBox pour afficher le contenu XML
            using (XmlDisplayForm displayForm = new XmlDisplayForm(xmlContent))
            {
                displayForm.ShowDialog();
                this.Hide();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            Form.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }

}

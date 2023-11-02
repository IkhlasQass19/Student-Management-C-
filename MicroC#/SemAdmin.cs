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
    public partial class SemAdmin : Form
    {
        private XDocument xmlData; // Stockez votre document XML ici
        public SemAdmin()
        {
            InitializeComponent();
            xmlData = XDocument.Load("C:\\Users\\XPS\\source\\repos\\SW\\SW\\XMLFile1.xml");

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /*
        private void sem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Effacez le tableau précédent
            tableLayoutPanel1.Controls.Clear();
            string selectedModule = sem.SelectedItem.ToString();

            string selectedSemester = selectedModule; // Remplacez par le semestre choisi
            int numberOfModules = 6; // Nombre de modules par semestre

            // Créez une ligne d'en-tête avec les titres de colonnes
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Nom", TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Prenom", TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "CNE", TextAlign = ContentAlignment.MiddleCenter }, 2, 0);

            for (int i = 1; i <= numberOfModules; i++)
            {
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Module " + i, TextAlign = ContentAlignment.MiddleCenter }, i + 2, 0);
            }

            // Code pour extraire les étudiants inscrits pour le semestre sélectionné
            var enrolledStudents = xmlData.Descendants("Inscrire")
                .Where(inscription => inscription.Attribute("CNE") != null)
                .Select(inscription => new
                {
                    CNE = (string)inscription.Attribute("CNE")
                })
                .Distinct()
                .ToList();

            int row = 1;

            // Parcourez les étudiants
            foreach (var student in enrolledStudents)
            {
                var studentDetails = xmlData.Descendants("Etudiant")
                    .Where(etudiant => etudiant.Attribute("CNE").Value == student.CNE)
                    .Select(etudiant => new
                    {
                        Nom = etudiant.Attribute("Nom").Value,
                        Prenom = etudiant.Attribute("Prenom").Value,
                        CNE = etudiant.Attribute("CNE").Value
                    })
                    .FirstOrDefault();

                tableLayoutPanel1.Controls.Add(new Label() { Text = studentDetails.Nom, TextAlign = ContentAlignment.MiddleCenter }, 0, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = studentDetails.Prenom, TextAlign = ContentAlignment.MiddleCenter }, 1, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = studentDetails.CNE, TextAlign = ContentAlignment.MiddleCenter }, 2, row);

                // Code pour extraire les modules auxquels l'étudiant est inscrit pour le semestre sélectionné
                var enrolledModulesForStudent = xmlData.Descendants("Inscrire")
                    .Where(inscription => inscription.Attribute("CNE") != null && inscription.Attribute("Id_module") != null)
                    .Where(inscription => inscription.Attribute("CNE").Value == student.CNE)
                    .Select(inscription => new
                    {
                        Id_module = inscription.Attribute("Id_module").Value,
                        IsEnrolled = "oui" // Par défaut, l'étudiant est inscrit à moins que ce module ne soit manquant
                    })
                    .GroupBy(module => module.Id_module)
                    .Select(group => group.FirstOrDefault()) // Prendre un module distinct

                    .Take(numberOfModules) // Prendre au maximum 6 modules
                    .ToList();

                int column = 3;
                for (int i = 1; i <= numberOfModules; i++)
                {
                    var module = enrolledModulesForStudent.FirstOrDefault(m => m.Id_module == i.ToString());
                    string isEnrolled = module != null ? "oui" : "non";
                    tableLayoutPanel1.Controls.Add(new Label() { Text = isEnrolled, TextAlign = ContentAlignment.MiddleCenter }, column, row);
                    column++;
                }

                row++;
            }
        }
        */
        private void sem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Effacez le tableau précédent
            tableLayoutPanel1.Controls.Clear();
            string selectedSemester = sem.SelectedItem.ToString();

            // Créez une ligne d'en-tête avec les titres de colonnes
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Nom", TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Prenom", TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = "CNE", TextAlign = ContentAlignment.MiddleCenter }, 2, 0);

            // Extraire les noms des modules pour le semestre sélectionné
            var moduleNames = xmlData.Descendants("Module")
                .Where(module => module.Attribute("semestre") != null && module.Attribute("semestre").Value == selectedSemester)
                .Select(module => new
                {
                    Id_module = module.Attribute("Id_module").Value,
                    Intitule = module.Attribute("intitule").Value
                });

            // Créer des étiquettes d'en-tête pour les modules
            int column = 3;
            foreach (var moduleName in moduleNames)
            {
                tableLayoutPanel1.Controls.Add(new Label() { Text = moduleName.Intitule, TextAlign = ContentAlignment.MiddleCenter, AutoSize = true }, column, 0);
                column++;
            }

            // Code pour extraire les étudiants inscrits pour le semestre sélectionné
            var enrolledStudents = xmlData.Descendants("Inscrire")
                .Where(inscription => inscription.Attribute("CNE") != null)
                .Select(inscription => new
                {
                    CNE = (string)inscription.Attribute("CNE")
                })
                .Distinct()
                .ToList();

            int row = 1;

            // Parcourez les étudiants
            foreach (var student in enrolledStudents)
            {
                var studentDetails = xmlData.Descendants("Etudiant")
                    .Where(etudiant => etudiant.Attribute("CNE").Value == student.CNE)
                    .Select(etudiant => new
                    {
                        Nom = etudiant.Attribute("Nom").Value,
                        Prenom = etudiant.Attribute("Prenom").Value,
                        CNE = etudiant.Attribute("CNE").Value
                    })
                    .FirstOrDefault();

                tableLayoutPanel1.Controls.Add(new Label() { Text = studentDetails.Nom, TextAlign = ContentAlignment.MiddleCenter }, 0, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = studentDetails.Prenom, TextAlign = ContentAlignment.MiddleCenter }, 1, row);
                tableLayoutPanel1.Controls.Add(new Label() { Text = studentDetails.CNE, TextAlign = ContentAlignment.MiddleCenter }, 2, row);

                // Code pour extraire les modules auxquels l'étudiant est inscrit pour le semestre sélectionné
                var enrolledModulesForStudent = xmlData.Descendants("Inscrire")
                    .Where(inscription => inscription.Attribute("CNE") != null && inscription.Attribute("Id_module") != null)
                    .Where(inscription => inscription.Attribute("CNE").Value == student.CNE)
                    .Select(inscription => new
                    {
                        Id_module = inscription.Attribute("Id_module").Value,
                        IsEnrolled = "oui" // Par défaut, l'étudiant est inscrit à moins que ce module ne soit manquant
                    })
                    .ToList();

                // Remplacer "Module 1", "Module 2", etc. par le nom du module
                column = 3;
                foreach (var moduleName in moduleNames)
                {
                    var module = enrolledModulesForStudent.FirstOrDefault(m => m.Id_module == moduleName.Id_module);
                    string isEnrolled = module != null ? "oui" : "non";
                    tableLayoutPanel1.Controls.Add(new Label() { Text = isEnrolled, TextAlign = ContentAlignment.MiddleCenter }, column, row);
                    column++;
                }

                row++;
            }
        }


        private void SemAdmin_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void XML_Click(object sender, EventArgs e)
        {
            Form1.Som = null;
            // Obtenez le semestre choisi depuis le ComboBox
            string selectedSemester = sem.SelectedItem.ToString();

            // Obtenez l'année en cours (vous devrez peut-être adapter cette partie en fonction de la façon dont vous suivez l'année en cours)
            string currentYear = DateTime.Now.Year.ToString();

            // Créez un document XML pour stocker les données
            XDocument xmlDoc = new XDocument(
                new XElement("StudentsForSemester")
            );

            // Code pour extraire les modules du semestre choisi
            var modulesForSemester = xmlData.Descendants("Module")
                .Where(module => module.Attribute("semestre") != null && module.Attribute("semestre").Value == selectedSemester)
                .Select(module => new
                {
                    Id_module = module.Attribute("Id_module").Value
                });

            // Code pour extraire les étudiants inscrits aux modules du semestre choisi
            var students = xmlData.Descendants("Inscrire")
                .Where(inscrire =>
                    inscrire.Attribute("CNE") != null &&
                    inscrire.Attribute("Id_module") != null &&
                    modulesForSemester.Any(m => m.Id_module == inscrire.Attribute("Id_module").Value))
                .Select(inscrire => new
                {
                    CNE = inscrire.Attribute("CNE").Value,
                    Id_module = inscrire.Attribute("Id_module").Value
                });

            foreach (var student in students)
            {
                string cne = student.CNE;

                // Recherchez les informations de nom, prénom et modules de l'étudiant
                var studentInfo = xmlData.Descendants("Etudiant")
                    .Where(etudiant => etudiant.Attribute("CNE").Value == cne)
                    .Select(etudiant => new
                    {
                        Nom = etudiant.Attribute("Nom").Value,
                        Prenom = etudiant.Attribute("Prenom").Value
                    })
                    .FirstOrDefault();

                string moduleId = student.Id_module;

                // Recherchez les informations du module inscrit
                var moduleInfo = xmlData.Descendants("Module")
                    .Where(module => module.Attribute("Id_module").Value == moduleId)
                    .Select(module => module.Attribute("intitule").Value)
                    .FirstOrDefault();

                if (studentInfo != null && !string.IsNullOrEmpty(moduleInfo))
                {
                    string nom = studentInfo.Nom;
                    string prenom = studentInfo.Prenom;

                    // Ajoutez les données au document XML
                    xmlDoc.Root.Add(
                        new XElement("Student",
                            new XAttribute("CNE", cne),
                            new XAttribute("Nom", nom),
                            new XAttribute("Prenom", prenom),
                            new XAttribute("ModuleInscrit", moduleInfo)
                        )
                    );
                }
            }

            // Affichez le document XML dans une nouvelle fenêtre ou un TextBox
            string xmlContent = xmlDoc.ToString();

            // Créez une nouvelle fenêtre ou utilisez une TextBox pour afficher le contenu XML
            using (XmlDisplayForm displayForm = new XmlDisplayForm(xmlContent))
            {
                displayForm.ShowDialog();
                this.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            Form.Show();
            this.Hide();
        }
    }
    }


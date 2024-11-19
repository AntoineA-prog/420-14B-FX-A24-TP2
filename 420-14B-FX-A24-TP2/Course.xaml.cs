using _420_14B_FX_A24_TP2.classes;
using _420_14B_FX_A24_TP2.enums;
using System;
using _420_14B_FX_A24_TP2.classes;
using _420_14B_FX_A24_TP2.enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _420_14B_FX_A24_TP2
{
    /// <summary>
    /// Logique d'interaction pour Course.xaml
    /// </summary>
    public partial class Course : Window
    {
        private List<Coureur> coureur;
        GestionCourse gestioncourse;

        public Course()
        {
            InitializeComponent();
        }


       

        private void AfficherListeCoureur()
        {
            //lstCourse.Items.Clear();

            //foreach (Coureur c in courses)
            //{
            //    lstCourse.Items.Add(c);
            //}
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            FormAjoutCoureur frmAjouterCoureur = new FormAjoutCoureur();


            bool? resultat = frmAjouterCoureur.ShowDialog();
            if (resultat == true)
            {
                Coureur nouvellePersonne = frmAjouterCoureur.Coureurs;
                coureur.Add(nouvellePersonne);

                AfficherListeCoureur();
                MessageBox.Show("Contact ajouter avec succes");
            }
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (lstCourse.SelectedItem != null)
            {
                Coureur coureurSelect = lstCourse.SelectedItem as Coureur;

                FormAjoutCoureur frmPersonne = new FormAjoutCoureur(coureurSelect, EtatFormulaire.Modifier );

                if (frmPersonne.ShowDialog() == true)
                {
                    AfficherListeCoureur();

                    MessageBox.Show("La personne a ete modifier avec succee!!");

                }

            }
            else
            {
                MessageBox.Show("Selectionner une personne");
            }
        }
        
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            

            AfficherListeCoureur();

        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lstCourse.SelectedItem != null)
            {
                Coureur coureurSelect = lstCourse.SelectedItem as Coureur;

                FormAjoutCoureur frmPersonne = new FormAjoutCoureur(coureurSelect, EtatFormulaire.Modifier);

                if (frmPersonne.ShowDialog() == true)
                {
                   
                    AfficherListeCoureur();
                    MessageBox.Show("La personne a ete supprimer");

                }

            }
            else
            {
                MessageBox.Show("vous devez selectionner une personne ");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gestioncourse.EnregistrerCourses(MainWindow.CHEMIN_FICHIER_COURSE, MainWindow.CHEMIN_FICHIER_COUREURS);
            MessageBox.Show("Sauvegarder! ");
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

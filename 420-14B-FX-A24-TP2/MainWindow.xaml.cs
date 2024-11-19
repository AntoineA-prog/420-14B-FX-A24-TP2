
using _420_14B_FX_A24_TP2.classes;
using _420_14B_FX_A24_TP2.enums;
using System.Windows;

namespace _420_14B_FX_A24_TP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GestionCourse courses;
        private List<Course> CoursesMain;

        /// <summary>
        /// Nom du fichier texte CSV contenant les informations sur la course pour les tests.
        /// </summary>
        public const String CHEMIN_FICHIER_COURSE = @"C:\data-420-14B-FX\TP2\Tests\courses.csv";

        /// <summary>
        /// Nom du fichier texte CSV contenant les informations sur les coureurs.
        /// </summary>
        public const String CHEMIN_FICHIER_COUREURS = @"C:\data-420-14B-FX\TP2\Tests\coureurs.csv";

        

        public MainWindow()
        {
            
            InitializeComponent();
            AfficherListeCourses();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           CoursesMain = new List<Course>();
           courses = new GestionCourse(CHEMIN_FICHIER_COURSE, CHEMIN_FICHIER_COUREURS);

            foreach (Course c in courses.Courses)
            {
                CoursesMain.Add(c);
            }

        }

        
        private void AfficherListeCourses()
        {
            foreach (Course c in CoursesMain) {
                
                lstCourses.Items.Add(c);
            }
            
        }

        private void btnNouveau_Click(object sender, RoutedEventArgs e)
        {
             FormCourse frmCourseInfo = new FormCourse();
            bool? resultat = frmCourseInfo.ShowDialog();
            if (frmCourseInfo.ShowDialog() == true)
            {
                Course nouvelleCourse = frmCourseInfo.Courses;
                lstCourses.Items.Add(nouvelleCourse);
                MessageBox.Show("Course rajouté avec succès");
            }

            
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lstCourses.SelectedItem != null)
            {
                Course courseSelected = lstCourses.SelectedItem as Course;

                FormCourse frmPersonne = new FormCourse(courseSelected);

                if (frmPersonne.ShowDialog() == true)
                {
                    AfficherListeCourses();

                    MessageBox.Show("La course a été modifié avec succee!!");

                }

            }
            else
            {
                MessageBox.Show("Selectionner une course");
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lstCourses.SelectedItem != null)
            {
                Course CourseSelected = lstCourses.SelectedItem as Course;

                FormCourse frmPersonne = new FormCourse(courseSelected);

                if (frmPersonne.ShowDialog() == true)
                {

                    AfficherListeCourses();
                    MessageBox.Show("La course a été supprimé");

                }

            }
            else
            {
                MessageBox.Show("vous devez selectionner une course");
            }
        }
    }
}
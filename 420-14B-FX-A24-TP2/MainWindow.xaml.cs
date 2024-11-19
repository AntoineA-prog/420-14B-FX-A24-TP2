
using _420_14B_FX_A24_TP2.classes;
using System.Windows;

namespace _420_14B_FX_A24_TP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
       

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
           
        }

        private void AfficherListeCourses()
        {
            GestionCourse course = new GestionCourse(CHEMIN_FICHIER_COURSE, CHEMIN_FICHIER_COUREURS);
            lstCourses .Items.Add(course);
            
        }

        private void btnNouveau_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
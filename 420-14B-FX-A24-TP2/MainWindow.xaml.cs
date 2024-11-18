
using _420_14B_FX_A24_TP2.classes;
using System.Windows;

namespace _420_14B_FX_A24_TP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GestionCourse _gestionCourse;
        
        public GestionCourse GestionCourse
        {
            get { return _gestionCourse; }
            set { _gestionCourse = value; }
        }
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void AfficherListeCourses()
        {
            lstCourses = GestionCourse.ChargerCourses();
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
using _420_14B_FX_A24_TP2.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _420_14B_FX_A24_TP2.classes
{
    public class GestionCourse
    {
        /// <summary>
        /// Les courses
        /// </summary>
		private List<Course> _courses;


        /// <summary>
        /// Obtien ou modifie les courses.
        /// </summary>
        public List<Course> Courses
        {
			get { return _courses; }
			set { _courses = value; }
		}

        /// <summary>
        /// permet de creer un objet de GestionCourse
        /// </summary>
        /// <param name="cheminFichierCourses">Chemin au fichier avec les courses</param>
        /// <param name="cheminFichierCoureurs_">Chemin au fichier avec les coureurs</param>
        public GestionCourse(string cheminFichierCourses, string cheminFichierCoureurs_)
        {
           Courses =new List<Course>();
           
        }

        /// <summary>
        ///Permet d'ajouter les courses du fichier dans la liste courses incluant les coureurs
        /// </summary>
        /// <param name="cheminFichierCourses"> Chemin pour acceder au donnee des courses</param>
        /// <param name="cheminFichierCoureurs">Chemin pour acceder au donnee des courseurs</param>
        private void ChargerCourses(string cheminFichierCourses, string cheminFichierCoureurs)
        {
            if(string.IsNullOrWhiteSpace(cheminFichierCoureurs))
               throw new ArgumentNullException("Error", "Le chemin pour le fichier coureurs est vide ");

            if(string.IsNullOrWhiteSpace(cheminFichierCourses))
                throw new ArgumentNullException("Error", "Le chemin pour le fichier course est vide ");

            string[] vectDonnee = Utilitaire.ChargerDonnees(cheminFichierCourses);
            string[] vectLigne;


            for (int i = 0; i <= vectDonnee.Length - 2; i++)
            {
                vectLigne = vectDonnee[i + 1].Split(';');
                Guid id = Guid.Parse(vectLigne[0]);
                string nom = vectLigne[1];
                string ville = vectLigne[2];
                Province province = (Province)(Convert.ToByte(vectLigne[3]));
                DateOnly date = DateOnly.Parse(vectLigne[4]);
                TypeCourse type = (TypeCourse)(Convert.ToByte(vectLigne[5]));
                ushort distance = ushort.Parse(vectLigne[6]);


                Course course = new Course(id, nom, date, ville, province, type, distance);
                ChargerCoureurs(course, cheminFichierCoureurs);
                Courses.Add(course);
            }

            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="course"></param>
        /// <param name="cheminFichierCoureurs"></param>
        private void ChargerCoureurs(Course course, string cheminFichierCoureurs)
        {

            if (string.IsNullOrWhiteSpace(cheminFichierCoureurs))
                throw new ArgumentNullException("Error", "Le chemin pour le fichier coureurs est vide ");

            if (course == null)
                throw new ArgumentNullException("Error", "Le chemin pour le fichier course est vide ");

            string[] vectDonnee = Utilitaire.ChargerDonnees(cheminFichierCoureurs);
            string[] vectLigne;


            for (int i = 0; i <= vectDonnee.Length - 2; i++)
            {
                vectLigne = vectDonnee[i + 1].Split(';');
                Guid id = Guid.Parse(vectLigne[0]);



                if(id == course.Id)
                {


                    ushort distance = ushort.Parse(vectLigne[1]);
                    string nom = vectLigne[1];
                    string prenom = vectLigne[2];
                    Categorie categorie = (Categorie)(Convert.ToByte(vectLigne[3]));
                    string ville = vectLigne[4];
                    Province province = (Province)(Convert.ToByte(vectLigne[5]));
                    TimeSpan temps = TimeSpan.Parse(vectLigne[6]);
                    bool abandon = bool.Parse(vectLigne[7]);

                    Coureur coureur = new Coureur(distance, nom, prenom, categorie, ville, province,temps,abandon);
                    course.Coureurs.Add(coureur);

                }





            }
        }

        /// <summary>
        /// ajoute une course a la liste si elle n'est pas nulle et si elle n'est pas repeter
        /// </summary>
        /// <param name="course">La course a ajouter</param>
        public void AjouterCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException("Error", "La course est vide.");

            if (Courses.Contains(course))
            {
                throw new InvalidOperationException("La course que vous voulez ajouter existe deja.");
            }

            
            Courses.Add(course);
            
            Courses.Sort();


        }

        /// <summary>
        /// verifier si la course existe et si elle est dans la liste puis l'efface de la liste
        /// </summary>
        /// <param name="course">Course a effeacer de la liste</param>
        /// <returns>retourn vrai si la liste est effacer, retourn faux si la course n'a pas ete effacer</returns>
        public bool SupprimerCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException("Error", "La course est vide.");

            if (!Courses.Contains(course))
            {
                throw new InvalidOperationException("La course n'est pas dans la liste");
            }

            foreach (Course courses in Courses)
            {
                if (course.Id == courses.Id)
                {
                    return Courses.Remove(course);
                }

            }
            
            
           return false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cheminFichierCourses"></param>
        /// <param name="cheminFichierCoureurs"></param>
        public void EnregistrerCourses(string cheminFichierCourses, string cheminFichierCoureurs)
        {
            if (string.IsNullOrWhiteSpace(cheminFichierCourses))
                throw new ArgumentNullException("Error", "Le chemin pour le fichier avec les courses est vide.");

            if (string.IsNullOrWhiteSpace(cheminFichierCoureurs))
                throw new ArgumentNullException("Error", "Le chemin pour le fichier avec les coureurs est vide.");
        }
    }
}

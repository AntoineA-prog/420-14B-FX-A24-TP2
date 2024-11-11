using _420_14B_FX_A24_TP2.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

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
        ///
        /// </summary>
        /// <param name="cheminFichierCourses"></param>
        /// <param name="cheminFichierCoureurs"></param>
        private void ChargerCourse(string cheminFichierCourses, string cheminFichierCoureurs)
        {
            if(string.IsNullOrWhiteSpace(cheminFichierCoureurs))
               throw new ArgumentNullException("Error", "Le chemin pour le fichier coureurs est vide ");

            if(string.IsNullOrWhiteSpace(cheminFichierCourses))
                throw new ArgumentNullException("Error", "Le chemin pour le fichier course est vide ");

            string[] vectDonnee = Utilitaire.ChargerDonnees(cheminFichierCourses,);
            string[] vectLigne;


            for (int i = 0; i <= vectDonnee.Length - 2; i++)
            {
                vectLigne = vectDonnee[i + 1].Split(';');
                Guid id = Guid.Parse(vectLigne[0]);
                string nom = vectLigne[1];
                string ville = vectLigne[2];
                Province province = (Province)(vectLigne[3]);
                DateOnly date = DateOnly.Parse(vectLigne[4]);
                TypeCourse type = (TypeCourse)(vectLigne[5]);
                ushort distance = ushort.Parse(vectLigne[6]);


                Course course=new Course(id, nom, ville, province, date, type,distance);

            }



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="course"></param>
        /// <param name="cheminFichierCoureurs"></param>
        private void ChargerCoureurs(Course course, string cheminFichierCoureurs)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="course"></param>
        public void AjouterCourse(Course course)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        //public bool SupprimerCourse(Course course)
        //{

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cheminFichierCourses"></param>
        /// <param name="cheminFichierCoureurs"></param>
        public void EnregistrerCourses(string cheminFichierCourses, string cheminFichierCoureurs)
        {

        }
    }
}

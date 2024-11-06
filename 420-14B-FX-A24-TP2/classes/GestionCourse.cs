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
		private Course _courses;


        /// <summary>
        /// Obtien ou modifie les courses.
        /// </summary>
        public Course Courses
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
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cheminFichierCourses"></param>
        /// <param name="cheminFichierCoureurs"></param>
        private void ChargerCourse(string cheminFichierCourses, string cheminFichierCoureurs)
        {

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
        public bool SupprimerCourse(Course course)
        {

        }

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

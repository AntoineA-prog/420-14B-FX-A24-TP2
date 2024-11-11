﻿
using _420_14B_FX_A24_TP2.enums;
using System;
using System.Globalization;


namespace _420_14B_FX_A24_TP2.classes
{
    /// <summary>
    /// Classe représentant une course à pied
    /// </summary>
    public class Course
    {

        public const int NOM_NB_CAR_MIN = 3;
        public const int VILLE_NB_CAR_MIN = 4;
        public const int DISTANCE_VAL_MIN = 1;



        /// <summary>
        /// Identifiant unique de la course
        /// </summary>
        private static Guid _id = Guid.NewGuid(); 


        /// <summary>
        /// Nom de la course
        /// </summary>
        private string _nom;

        /// <summary>
        /// Date de la course
        /// </summary>
        private DateOnly _date;

        /// <summary>
        /// Ville où a lieu la course
        /// </summary>
        private string _ville;

        /// <summary>
        /// Province où a lieu la course
        /// </summary>
        private Province _province;

        /// <summary>
        /// Type de course
        /// </summary>
        private TypeCourse _typeCourse;


        /// <summary>
        /// Distance de la course
        /// </summary>
        private ushort _distance;


        /// <summary>
        /// Liste des coureurs 
        /// </summary>
        private List<Coureur> _coureurs;




        /// <summary>
        /// Obtient ou définit l'identifiant unique d'une course
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set {
                _id = value; 
            }
        }


        /// <summary>
        ///Obtien ou modifie le nom de la course.
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _nom.</value>
        /// <exception cref="System.ArgumentNullException">Lancée lorsque que le nom est nul ou n'a aucune valeur.</exception>
        /// <exception cref="System.ArgumentNullException">Lancé lors que le nom a moins de NOM_NB_CAR_MIN caractères.</exception>

        public string Nom
        {
            get { return _nom; }

            set 
            {
                if (string.IsNullOrEmpty(value) || value.Length >= NOM_NB_CAR_MIN)
                {
                    _nom = value.Trim().ToUpper();
                }
                else
                    throw new ArgumentNullException("ERREUR", "Le type de course ne se retrouve pas dans la liste");

            }
        }


        /// <summary>
        ///Obtien ou modifie la date de la course
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _date.</value>
        public DateOnly Date
        {
            get { return _date; }
            set { _date = value; }
        }


        /// <summary>
        ///Obtien ou modifie la ville où a lieu la course
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _ville.</value>
        /// <exception cref="System.ArgumentNullException">Lancée lorsque que la ville est nulle ou n'a aucune valeur.</exception>
        /// <exception cref="System.ArgumentNullException">Lancé lors que la ville a moins de VILLE_NB_CAR_MIN caractères.</exception>
        public string Ville
        {
            get { return _ville; }
            set 
            {
                if (string.IsNullOrEmpty(value) || value.Length >= VILLE_NB_CAR_MIN)
                {
                    _nom = value.Trim();
                }
                else
                {
                    throw new ArgumentNullException("ERREUR", "Le type de course ne se retrouve pas dans la liste");
                }

                
            }
        }




        /// <summary>
        ///Obtien ou modifie la province où a lieu la course
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _province.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque la valeur de la province n'est pas entre PROVINCE_MIN_VAL et PROVINCE_MAX_VAL.</exception>
        public Province Province
        {
            get { return _province; }
            set 
            {
                if (!Enum.IsDefined(typeof(Province), value))
                    throw new ArgumentOutOfRangeException("ERREUR", "La province ne se retrouve pas dans la liste");        
                _province = value; 
            }
        }


        /// <summary>
        ///Obtien ou modifie le type de course.
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _type.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque que le type de course n'est pas entre TYPE_COURSE_MIN_VAL et TYPE_COURSE_MAX_VAL.</exception>
        public TypeCourse TypeCourse
        {
            get { return _typeCourse; }
            set 
            {
                if (!Enum.IsDefined(typeof(Province), value))
                    throw new ArgumentOutOfRangeException("ERREUR", "Le type de course ne se retrouve pas dans la liste");
                _typeCourse = value; 
            }
        }

        /// <summary>
        ///Obtien ou modifie la distance de la course en km
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _distance.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque que la distance est inférieure à DISTANCE_VAL_MIN.</exception>
        public ushort Distance
        {
            get { return _distance; }
            set 
            {
                if (value > DISTANCE_VAL_MIN)
                    _distance = value; 
                else
                    throw new ArgumentOutOfRangeException("ERREUR", "Le type de course ne se retrouve pas dans la liste");
            }
        }

        /// <summary>
        ///Obtien ou modifie la liste des coureurs
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _coureurs.</value>
        public List<Coureur> Coureurs
        {
            get { return _coureurs; }
            set { _coureurs = value; }
        }


     

        /// <summary>
        ///Obtient le nombre de coureurs participant à la course
        /// </summary>
        /// <value>Obtien la valeur de l'attribut :  _coureurs.Count.</value>
        public int NbParticipants
        {
            get {
                throw new NotImplementedException();
            }
      
        }

        /// <summary>
        ///Obtien le temps de course moyen
        /// </summary>
        /// <value>Obtien la valeur retourné par la méthode : CalculerTempsCourseMoyen() </value>
        public TimeSpan TempCourseMoyen
        {
            get { 
                throw new NotImplementedException(); 
            }
          
        }


   

        /// <summary>
        /// Permet de constuire un objet de type Course
        /// </summary>
        /// <param name="nom">Nom de la course</param>
        /// <param name="date">Date à laquelle a lieu la course</param>
        /// <param name="ville">Ville où a lieu la course</param>
        /// <param name="province">Province ou a lieu la course</param>
        /// <param name="typeCourse">Type de course</param>
        /// <param name="distance">Distance de la course</param>
        /// <remarks>Initialise une liste de coureurs vide</remarks>
        public Course(Guid id, string nom, DateOnly date, string ville, Province province, TypeCourse typeCourse, ushort distance )
        {
            Id = id;
            Nom = nom;
            Date = date;
            Ville = ville;
            Province = province;
            TypeCourse = typeCourse;
            Distance = distance;
            Coureurs = new List<Coureur>();
           
        }


       

        /// <summary>
        /// Permet l'ajout d'un coureur à la liste des coureurs
        /// </summary>
        /// <param name="coureur"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AjouterCoureur(Coureur coureur)
        {
            //Vérification ; le coureur reçu dans la fonction actuelle ne peut pas être null
            if (coureur == null)
            {
                //À changer
                throw new NotImplementedException();
            }
            else if(ObtenirCoureurParNoDossard(coureur.Dossard) == coureur)
            {
                throw new NotImplementedException();
            }
            
            //Vérification ; Si le dossard est null et assumant que le coureur reçu n'est pas null
            if (ObtenirCoureurParNoDossard(coureur.Dossard) == null)
            {
                int i = 0;
                foreach (Coureur coureurChoisi in Coureurs)
                {
                    if (coureurChoisi == Coureurs[i])
                    {
                        throw new NotImplementedException();

                    }
                    i++;
                }
                Coureurs.Add(coureur);
                //À changer

            }
            //Switch?
            TrierCoureurs();
            //good sort?
        }


       

        /// <summary>
        ///  Permet d'obtenir un coureur à partir de son numéro de dossard.Si aucun coureur ne porte le numéro de dossard
        /// recherché, alors la valeur nulle est retournée sinon le coureur trouvé est retourné.
        /// </summary>
        /// <param name="noDossard"></param>
        /// <returns></returns>

        public Coureur ObtenirCoureurParNoDossard(ushort noDossard)
        {
            foreach (Coureur coureur in Coureurs)
            {

               //ok
                 if (coureur.Dossard == noDossard)
                {
                    return coureur;

                }
                //ok
                else if (coureur.Dossard > 1)
                {
                    throw new NotImplementedException();
                }
            }

            return null;
            //À implémenter dans la fonction AjouterCoureur.
        }

        /// <summary>
        /// Permet de calculer le temps moyen de la course.Les coureurs ayant abandonné la course sont exclus du calcul
        /// </summary>
        private TimeSpan CalculerTempsCourseMoyen()
        {
            

            foreach (Coureur coureur in Coureurs)
            {

                TimeOnly TempCourseMoyen = new TimeOnly(0);
                //ok
                if (!coureur.Abandon)
                {
                    TempCourseMoyen = TempCourseMoyen.Add(coureur.Temps);

                }
               
            }
            return TempCourseMoyen;
        }
        /// <summary>
        ///Permet de retirer un coureur de la liste de coureurs
        /// </summary>
        /// <param name="coureur"></param>
        public void SupprimerCoureur(Coureur coureur)
        {
            int i = 0;
            foreach (Coureur coureurChoisi in Coureurs)
            {
                if (coureurChoisi == Coureurs[i])
                {
                    Coureurs.RemoveAt(i);

                }
                i++;
            }
        }
        
        /// <summary>
        /// Permet de trier la liste des coureurs selon le temps de course en ajustant le rang des coureurs.
        /// </summary>
        public void TrierCoureurs()
        {
            Coureurs.Sort();
        }

        /// <summary>
        /// Permet de comparer deux courses
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not Course) return false;


            return this == (Course)obj;
        }

        /// <summary>
        ///^Permet de comparer deux courses
        /// </summary>
        /// <param name="courseGauche"></param>
        /// <param name="courseDroite"></param>
        /// <returns></returns>
        public static bool operator ==(Course courseGauche, Course courseDroite)
        {
            if (object.ReferenceEquals(courseGauche, courseDroite))
                return true;

            if (courseGauche == null || courseDroite == null)
                return false;

            if (courseGauche.Equals(courseDroite))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Permet de comparer deux courses
        /// </summary>
        /// <param name="courseGauche"></param>
        /// <param name="courseDroite"></param>
        /// <returns></returns>
        public static bool operator !=(Course courseGauche, Course courseDroite)
        {
            return (courseGauche != courseDroite);
        }

        /// <summary>
        /// Permet la représentation des données sous forme string
        /// </summary>
        public override string ToString()
        {
            return $"{Id}, {Nom}, {Date}, {Ville}, {Province}, {TypeCourse}, {Distance}";
        }
    }
}


using _420_14B_FX_A24_TP2.enums;
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
        /// Nombre de participants
        /// </summary>
        private int _nbParticipants;

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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ERREUR", $"Le nom est vide");

                    
                }
                else if(value.Length < NOM_NB_CAR_MIN)
                {
                    throw new ArgumentOutOfRangeException("ERREUR", $"Le nom ne respecte pas le nombre de caractères minimum ({NOM_NB_CAR_MIN})");

                }
                else
                    _nom = value.Trim().ToUpper();
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
        /// <exception cref="System.ArgumentOutOfRangeException">Lancé lors que la ville a moins de VILLE_NB_CAR_MIN caractères.</exception>
        public string Ville
        {
            get { return _ville; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ERREUR", $"La ville entrée est vide");
                }
                else if (value.Trim().Length < VILLE_NB_CAR_MIN)
                    throw new ArgumentOutOfRangeException("La ville entrée ne respecte pas le nombre de caractères minimum ({VILLE_NB_CAR_MIN})");
                else if (value.Length >= VILLE_NB_CAR_MIN)
                {
                    _ville = value.Trim();
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
                if (!Enum.IsDefined(typeof(TypeCourse), value))
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
                if (value < DISTANCE_VAL_MIN)
                    throw new ArgumentOutOfRangeException("ERREUR", "Le type de course ne se retrouve pas dans la liste");
               
                    


                _distance = value;
            }
        }

        /// <summary>
        ///Obtien ou modifie la liste des coureurs
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _coureurs.</value>
        public List<Coureur> Coureurs
        {
            get { return _coureurs; }
            set { 

                _coureurs = value; 
            }
        }



        
        /// <summary>
        ///Obtient le nombre de coureurs participant à la course
        /// </summary>
        /// <value>Obtien la valeur de l'attribut :  _coureurs.Count.</value>
        public int NbParticipants
        {
            get {

                _nbParticipants = Coureurs.Count;

                return _nbParticipants;
            }
            

      
        }


        private TimeSpan _TempsCourseMoyen;

        /// <summary>
        ///Obtien le temps de course moyen
        /// </summary>
        /// <value>Obtien la valeur retourné par la méthode : CalculerTempsCourseMoyen() </value>
        public TimeSpan TempCourseMoyen
        {
            get { 
                return _TempsCourseMoyen;
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

            if (id == Guid.Empty)
                throw new ArgumentException("La valeur attitré à l'id est vide. Veuillez ne pas personnaliser l'ID.");
            else
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
        /// <exception cref="InvalidOperationException">ne référence nulle est rentré pour l'objet coureur</exception>
        public void AjouterCoureur(Coureur coureur)
        {
            //Vérification ; le coureur reçu dans la fonction actuelle ne peut pas être null
            if (coureur == null)
            {
               
                throw new ArgumentNullException("Error", "Aucun coureur n'a été rentré");
            }
            else if(ObtenirCoureurParNoDossard(coureur.Dossard) != null)
            {
                throw new InvalidOperationException(); 
            }
            
            //Vérification ; Si le dossard est null et assumant que le coureur reçu n'est pas null
            else
                Coureurs.Add(coureur);
                //À changer

            
            //Switch?
            TrierCoureurs();
            //good sort?
        }




        /// <summary>
        /// Permet d'obtenir un coureur à partir de son numéro de dossard.Si aucun coureur ne porte le numéro de dossard
        /// recherché, alors la valeur nulle est retournée sinon le coureur trouvé est retourné.
        /// </summary>
        /// <param name="noDossard"></param>
        /// <returns>Retourne coureur, null autrement</returns>
        /// <exception cref="ArgumentException">Se lance si le numéro de dossard est inférieur à 1</exception>

        public Coureur ObtenirCoureurParNoDossard(ushort noDossard)
        {

             //ok
            if (noDossard < 1)
            {
                throw new ArgumentOutOfRangeException("Erreur", "Le numéro de dossard est inférieur à 1");
            }

            foreach (Coureur coureur in Coureurs)
            {

               //ok
                 if (coureur.Dossard == noDossard)
                 {
                    return coureur;
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
            if (coureur == null)
                throw new ArgumentNullException("Aucun coureur n'a été entré(null)");

            bool valid = false;
            

            /// utiliser for
            /// 

            for (int i = 0; i < Coureurs.Count; i++)
            {
                if (coureur == Coureurs[i])
                {
                    Coureurs.RemoveAt(i);
                    valid = true;
                }
            }
            //foreach (Coureur coureurChoisi in Coureurs)
            //{
            //    if (coureurChoisi == Coureurs[i])
            //    {
            //        Coureurs.RemoveAt(i);
            //        valid = true;
            //    }
                
                
            //}
            if (!valid)
            {
                throw new InvalidOperationException("Le coureur est inexistant");
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
        /// Permet de retourner deux courses en fonction de leur date OU leur nom
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Course other)
        {
            if (other is null)
                return 1;

            //Date
            int date = Date.CompareTo(other.Date);
            if (date < 0)
                return date;
            
            //Nom
            int nom = string.Compare(Nom, other.Nom, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace);
            if (nom > 0)
                return nom;

            

            return nom; 

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

            if ((Object)courseGauche == null || (Object)courseDroite == null)
                return false;

            if ( courseGauche.Nom == courseDroite.Nom && courseGauche.Date == courseDroite.Date && courseGauche.Date == courseDroite.Date && courseGauche.Ville == courseDroite.Ville && courseGauche.Province == courseDroite.Province && courseGauche.TypeCourse == courseDroite.TypeCourse && courseGauche.Distance == courseDroite.Distance)
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
            return !(courseGauche == courseDroite);
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

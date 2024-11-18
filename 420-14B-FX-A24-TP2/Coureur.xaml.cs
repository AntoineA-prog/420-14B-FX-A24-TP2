using _420_14B_FX_A24_TP2.enums;
using System;
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
    /// Logique d'interaction pour Coureur.xaml
    /// </summary>
    public partial class formAjoutCoureur : Window
    {
        private Coureur _coureur;

        public Coureur Coureurs
        {
            get { return _coureur; }
            private set { _coureur = value; }
        }


        private EtatFormulaire _etat;

        public EtatFormulaire Etat
        {
            get { return _etat; }
            private set { _etat = value; }
        }

        public formAjoutCoureur(Coureur coureurs=null, EtatFormulaire etat=EtatFormulaire.Ajouter)
        {
            Coureurs = coureurs;
            Etat = etat;
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private bool Validerformulaire()
        {
            StringBuilder sb = new StringBuilder();












            return true;
        }
    }
}

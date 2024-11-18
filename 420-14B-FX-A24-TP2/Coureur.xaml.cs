using _420_14B_FX_A24_TP2.classes;
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
    public partial class Coureur : Window
    {

        public const byte DOSSARD_VAL_MIN = 1;
        public const byte NOM_NB_CARC_MIN = 3;
        public const byte PRENOM_NB_CARC_MIN = 3;
        public const byte VILLE_NB_CARC_MIN = 4;



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

        public Coureur(Coureur coureurs = null, EtatFormulaire etat = EtatFormulaire.Ajouter)
        {
            Coureurs = coureurs;
            Etat = etat;
            InitializeComponent();
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }





        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnModifier.Content = Etat;
            tbTitre.Text = $"{Etat} d'un coureur ";
            switch (Etat)
            {
                case EtatFormulaire.Ajouter:
                    break;
                case EtatFormulaire.Modifier:
                case EtatFormulaire.Supprimer:

                    if (Etat == EtatFormulaire.Supprimer || EtatFormulaire.Modifier == Etat)
                    {
                        txtNoDossard.IsEnabled = false;
                        

                    }
                    break;

            }



        }

        private bool Validerformulaire()
        {
            StringBuilder sb = new StringBuilder();

            if (ushort.Parse(txtNoDossard.Text) < DOSSARD_VAL_MIN || string.IsNullOrWhiteSpace(txtNoDossard.Text))
                sb.AppendLine($"Veuillez inscrire le Numero du dossard, il doit etre superieur a {DOSSARD_VAL_MIN}");

            if (string.IsNullOrWhiteSpace(txtNom.Text) || txtNom.Text.Trim().Length < NOM_NB_CARC_MIN)
                sb.AppendLine($"Le nom doit contenir au moin {NOM_NB_CARC_MIN} caractere et ne doit pas etre nulle.");

            if (string.IsNullOrWhiteSpace(txtPrenom.Text) || txtPrenom.Text.Trim().Length < PRENOM_NB_CARC_MIN)
                sb.AppendLine($"Le nom doit contenir au moin {PRENOM_NB_CARC_MIN} caractere et ne doit pas etre nulle.");

            if (!Enum.IsDefined(typeof(Categorie), cboCategorie.SelectedIndex))
                sb.AppendLine($"Choisir une categorie");

            if (string.IsNullOrWhiteSpace(txtVille.Text) || txtVille.Text.Trim().Length < VILLE_NB_CARC_MIN)
                sb.AppendLine($"Le nom doit contenir au moin {VILLE_NB_CARC_MIN} caractere et ne doit pas etre nulle.");

            if (!Enum.IsDefined(typeof(Province), cboProvince.SelectedIndex))
                sb.AppendLine("Choisir une province");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Validation Formulaire");
                return false;
            }


            return true;
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (Etat != EtatFormulaire.Supprimer)
            {

                if (Validerformulaire())
                {

                    if (Etat == EtatFormulaire.Ajouter)
                    {


                        Coureur coureurNew = new Coureur(ushort.Parse(txtNoDossard.Text), txtNom.Text, txtPrenom.Text, (Categorie)cboCategorie.SelectedIndex, txtVille.Text, (Province)cboProvince.SelectedIndex, (TimeSpan)tsTemps.Value, cbAbandon);
                        Course.AjouterCoureur(coureurNew);
                        DialogResult = true;

                    }
                    else
                    {
                        
                        Coureurs.Nom = txtNom.Text;
                        Coureurs.Prenom = txtPrenom.Text;
                        Coureurs.Categorie = (Categorie)cboCategorie.SelectedIndex;
                        Coureurs.Ville = txtVille.Text;
                        Coureurs.Province = (Province)cboProvince.SelectedIndex;
                        Coureurs.Temps = (TimeSpan)tsTemps.Value;
                        Coureurs.Abandon = cbAbandon;
                    }
                    DialogResult = true;

                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Etes-vous sur de vouloir supprimer?", "suppresion d'un contact", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                if (result == MessageBoxResult.Yes)
                {
                    Coureur supCoureur =new Coureur(ushort.Parse(txtNoDossard.Text), txtNom.Text, txtPrenom.Text, (Categorie)cboCategorie.SelectedIndex, txtVille.Text, (Province)cboProvince.SelectedIndex, (TimeSpan)tsTemps.Value, cbAbandon);
                    Course.SupprimerCoureur(supCoureur);

                    DialogResult = true;

                }
                else
                {
                    DialogResult = false;
                }
            }
        }
    }
}

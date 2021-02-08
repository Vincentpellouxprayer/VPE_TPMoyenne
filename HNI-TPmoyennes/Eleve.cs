using System;
using System.Collections.Generic;
using System.Text;

namespace VPE_TPmoyennes
{
    public class Eleve : Classe
    {
        private string Prenom;
        private string Nom;
        private List<Note> Notes = new List<Note>();
        private static int nbNotes = 1;
        private float CumulMat = 0;
        private float CumulGene = 0;
        private int cpt = 0;
        private List<int> Mat = new List<int>();

        public string prenom
        {
            get { return Prenom; }
        }
        public string nom
        {
            get { return Nom; }
        }
        public Eleve(string NomClasse, string prenom, string nom)
            : base(NomClasse)
        {
            this.Prenom = prenom;
            this.Nom = nom;
        }
        public void ajouterNote(Note note)
        {
            try
            {
                if (nbNotes > 200)
                {
                    throw new Exception("Trop de notes pour un eleve");
                }
                Notes.Add(note);
                nbNotes += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public override float Moyenne(int IdMat)
        {
            cpt = 0;
            CumulMat = 0;
            for (int inote = 0; inote < Notes.Count; inote++)
            {
                if (Notes[inote].matiere == IdMat)
                {
                    CumulMat += Notes[inote].note;
                    cpt += 1;
                }
            }
            if (cpt == 0)
            {
                return 0;
            }
            else
            {
                return (float)decimal.Round((decimal)(CumulMat / cpt),2);
            }
        }
        public override float Moyenne()
        {
            cpt = 0;
            CumulGene = 0;
            for (int imat = 0; imat < Notes.Count; imat++)
            {
                if (Mat.Contains(Notes[imat].matiere) == false)
                {
                    Mat.Add(Notes[imat].matiere);
                }
            }
            foreach (int elem in Mat)
            {
                CumulGene += Moyenne(Mat[elem]);
                cpt += 1;
            }
            if (cpt == 0)
            {
                return 0;
            }
            else
            {
                return (float)decimal.Round((decimal)(CumulGene / cpt),2);
            }
        }
    }
}

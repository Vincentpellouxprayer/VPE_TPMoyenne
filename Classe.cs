using System;
using System.Collections.Generic;
using System.Text;

namespace VPE_TPmoyennes
{
    public class Classe
    {
        private float MoyGeneral;
        private float MoyMatiere;
        private static int NbEleve = 1;
        private static int NbMat = 0;
        private int cpt;
        private List<Eleve> Eleves = new List<Eleve>();
        protected List<string> Matieres;

        public List<int> IDMatieres { get; private set; }

        public string nomClasse { get; private set; }

        public Classe(string name)
        {
            this.nomClasse = name;
            Matieres = new List<string>();
            IDMatieres = new List<int>();
        }

        public void ajouterEleve(string prenom, string nom)
        {
            try
            {
                if (NbEleve > 30)
                {
                    throw new Exception("Trop d'eleves dans une classe");
                }
                Eleve etu = new Eleve(nomClasse, prenom, nom) ;
                Eleves.Add(etu);
                NbEleve += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ajouterMatiere(string nomMat)
        {
            NbMat = 1;
            try
            {
                if (NbMat == 10)
                {
                    throw new Exception("Trop de matiere pour une classe");
                }
                IDMatieres.Add(NbMat);
                Matieres.Add(nomMat);
                NbMat += 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           

        }

        public virtual float Moyenne(int Idmat)
        {
            MoyMatiere = 0;
            cpt = 0;
            for (int ieleve=0; ieleve <Eleves.Count; ieleve++)
            {
                MoyMatiere += Eleves[ieleve].Moyenne(Idmat);
                cpt += 1;
            }
            if (cpt == 0)
            {
                return 0;
            }
            else
            {
                return (float)decimal.Round((decimal)(MoyMatiere / cpt), 2);
            }
        }
        public virtual float Moyenne()
        {
            MoyGeneral = 0;
            cpt = 0;
            for (int ieleve = 0; ieleve < Eleves.Count; ieleve++)
            {
                MoyGeneral += Eleves[ieleve].Moyenne();
                cpt += 1;
            }
            if (cpt == 0)
            {
                return 0;
            }
            else
            {
                return (float)decimal.Round((decimal)(MoyGeneral / cpt), 2);
            }
        }
        public List<string> matieres
        {
            get { return Matieres; }
        }
        public List<int> idmatieres
        {
            get { return IDMatieres; }
        }
        public List<Eleve> eleves
        {
            get { return Eleves; }
        }
    }
}

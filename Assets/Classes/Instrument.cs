using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class Instrument
    {
        public Instrument()
        {
            EmplacementsMusique = new List<string>();
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private List<string> emplacementsMusique;
        public List<string> EmplacementsMusique
        {
            get { return emplacementsMusique; }
            set { emplacementsMusique = value; }
        }

        private string emplacementTexture;

        public string EmplacementTexture
        {
            get { return emplacementTexture; }
            set { emplacementTexture = value; }
        }

        // autre données relatives au jeu
    }
}

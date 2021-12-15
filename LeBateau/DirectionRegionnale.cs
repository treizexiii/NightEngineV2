using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeBateau
{
    public class DirectionRegionnale
    {
        public int code { get; set; }
        public string libelle { get; set; }
        public List<Agence> Agences { get; set; }

        public void CreerAgence()
        {
            throw new System.NotImplementedException();
        }

        public void FermerAgence()
        {
            throw new System.NotImplementedException();
        }
    }
}
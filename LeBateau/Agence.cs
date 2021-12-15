using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeBateau
{
    public class Agence
    {
        public int code { get; set; }
        public string intitule { get; set; }
        public DateTime horraire { get; set; }
        public DateTime dateCreation { get; set; }
        public DateTime? dateFermeture { get; set; }
        public List<Person> Personnels { get; set; }

        public void Recruter(Person person)
        {
            throw new System.NotImplementedException();
        }

        public void Licencier()
        {
            throw new System.NotImplementedException();
        }
    }
}
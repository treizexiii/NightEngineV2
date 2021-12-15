using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeBateau
{
    public class Person
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime dateArrive { get; set; }
        public DateTime dateDepart { get; set; }

        public void Travaille()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Projet
    {
        public int ID { get; set; }
        public string nameProjet { get; set; }
        public string theme { get; set; }
        public string description { get; set; }
        public Instructor Encadrant { get; set; }
        public ICollection<Student> Binome { get; set; }

    }
}

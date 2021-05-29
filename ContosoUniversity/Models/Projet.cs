using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Projet
    {
        public int ID { get; set; }
        [Display(Name = "Project Name")]
        public string nameProjet { get; set; }
        [Display(Name = "Project Theme")]
        public string theme { get; set; }
        [Display(Name = "Project Description")]
        public string description { get; set; }
        [Display(Name = "Instructor ID")]
        public Instructor Encadrant { get; set; }
        public ICollection<Student> Binome { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAsp.Models
{
    public class Societe
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = " Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = " Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        //Relationships

        public List<Offre> Offres { get; set; }


        public string NomSociete
        {
            get
            {
                return NomSociete;
            }
        }
    }
}

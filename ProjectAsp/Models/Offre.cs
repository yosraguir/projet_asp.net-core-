using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAsp.Models
{
    public class Offre
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        [Display(Name = "Image")]
        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //OffreCategory
        [Display(Name = "Category")]
        public int OffreCategoryId { get; set; }
        [ForeignKey("OffreCategoryId")]

        public OffreCategory OffreCategory { get; set; }

        //RelationShip 

        public List<Candidat_Offre> Candidat_Offres { get; set; }

        //Societe
        [Display(Name = "Societe")]
        public int SocieteId { get; set; }
        [ForeignKey("SocieteId")]

        public Societe Societe { get; set; }

        //Manager
        [Display(Name = "Manager")]
        public int MangaerId { get; set; }
        [ForeignKey("ManagerId")]

        public Manager Manager { get; set; }


   
    }
}

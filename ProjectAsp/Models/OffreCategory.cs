using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAsp.Models
{
    public class OffreCategory
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }

        //Relationships

        public List<Offre> Offres { get; set; }
    }
}

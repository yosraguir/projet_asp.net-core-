using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAsp.Models
{
    
    public class Candidat_Offre
    {
        [Key]
        public int Id { get; set; }

        public int OffreId { get; set; }
        public Offre Offre { get; set; }

        public int CandidatId { get; set; }
        public Candidat Candidat { get; set; }
    }
}

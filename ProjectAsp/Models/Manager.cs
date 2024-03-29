﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAsp.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Biography is required")]
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationships

        public List<Offre> Offres { get; set; }

    }
}

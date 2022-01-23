using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectAsp.Models;

namespace ProjectAsp.Data
{
    public class ProjectAspContext : DbContext
    {
        public ProjectAspContext (DbContextOptions<ProjectAspContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectAsp.Models.Offre> Offre { get; set; }

        public DbSet<ProjectAsp.Models.Candidat> Candidat { get; set; }

        public DbSet<ProjectAsp.Models.Manager> Manager { get; set; }

        public DbSet<ProjectAsp.Models.Societe> Societe { get; set; }

        public DbSet<ProjectAsp.Models.OffreCategory> OffreCategory { get; set; }
    }
}

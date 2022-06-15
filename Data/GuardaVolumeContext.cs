using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GuardaVolume.Models;

    public class GuardaVolumeContext : DbContext
    {
        public GuardaVolumeContext (DbContextOptions<GuardaVolumeContext> options)
            : base(options)
        {
        }

        public DbSet<GuardaVolume.Models.Usuario> Usuario { get; set; }

        public DbSet<GuardaVolume.Models.Armario> Armario { get; set; }

        public DbSet<GuardaVolume.Models.Compartimento> Compartimento { get; set; }
    }

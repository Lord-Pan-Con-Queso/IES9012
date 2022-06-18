﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IES9012.Core.Modelos;

namespace IES9012.UI.Data
{
    public class IES9012Context : DbContext
    {
        public IES9012Context (DbContextOptions<IES9012Context> options)
            : base(options)
        {
        }

        public DbSet<Estudiante>? Estudiantes { get; set; }
        public DbSet<Inscripcion>? Inscripciones { get; set; }
        public DbSet<Materia>? Materias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 

        
            modelBuilder.Entity<Materia>().ToTable("Materias");
            modelBuilder.Entity<Inscripcion>().ToTable("Inscripciones");
            modelBuilder.Entity<Estudiante>().ToTable("Estudiantes");}
    }
}


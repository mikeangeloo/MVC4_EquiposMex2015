﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EquiposMex.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Equipos_MexicoEntities : DbContext
    {
        public Equipos_MexicoEntities()
            : base("name=Equipos_MexicoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<DIRECTOR> DIRECTOR { get; set; }
        public DbSet<EQUIPO> EQUIPO { get; set; }
        public DbSet<JUGADOR> JUGADOR { get; set; }
        public DbSet<PADRE> PADRE { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}

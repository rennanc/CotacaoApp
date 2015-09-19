using CotacaoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CotacaoApp.DAO
{
    public class DefaultConnection : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Proposta> Proposta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
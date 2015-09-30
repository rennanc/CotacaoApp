﻿using CotacaoApp.Models;
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
        public DbSet<Condutor> Pessoa { get; set; }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<Cobertura> Cobertura { get; set; }
        public DbSet<Seguradora> Seguradora { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
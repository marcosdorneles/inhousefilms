﻿using System;
using filmesInHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace filmesInHouse.Context
{
	public class FilmesContext : DbContext
	{

		public FilmesContext(DbContextOptions options) : base(options)
		{

		}

		public FilmesContext()
		{
		}

		public virtual DbSet<Models.Filme> Filmes { get; set; }
        public virtual DbSet<Diretor> Diretores { get; set; }
        public virtual DbSet<FilmeDiretor> FilmeDiretores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("ServerConnection");
			}
		}
	}
}


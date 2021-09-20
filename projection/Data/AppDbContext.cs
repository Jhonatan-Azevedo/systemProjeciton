using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using systemProjection.Data;

namespace systemProjection.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Contrato> Contrato{ get; set; }
		public DbSet<ContratoItem> ContratoItem { get; set; }
		public DbSet<ContratoItemParceiro> ContratoItemParceiros { get; set; }
		public DbSet<ContratoPessoa> ContratoPessoa { get; set; }
		public DbSet<Usuario> Usuario { get; set; }
		public DbSet<Pessoa> Pessoa { get; set; }
		public DbSet<Faturamento> Faturamentos { get; set; }
		#region Criação e config das Tables
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Set Produtos
			modelBuilder.Entity<Produto>()
				.Property(p => p.Descricao).HasMaxLength(20);

			//Set Pessoa
			modelBuilder.Entity<Pessoa>()
				.Property(p => p.NomeRazaoSocial).HasMaxLength(200);
			modelBuilder.Entity<Pessoa>()
				.Property(p => p.NomeFantasia).HasMaxLength(200);
			modelBuilder.Entity<Pessoa>()
				.Property(p => p.CpfCnpj).HasMaxLength(15);
			modelBuilder.Entity<Pessoa>()
				.Property(p => p.CelularTelefone).HasMaxLength(11);
			modelBuilder.Entity<Pessoa>()
				.Property(p => p.Email).HasMaxLength(100);

			//Set Usuario
			modelBuilder.Entity<Usuario>()
				.Property(p => p.Nome).HasMaxLength(100);
			modelBuilder.Entity<Usuario>()
				.Property(p => p.Email).HasMaxLength(100);
			modelBuilder.Entity<Usuario>()
				.Property(p => p.Senha).HasMaxLength(100);
			modelBuilder.Entity<Usuario>()
				.Property(p => p.Setor).HasMaxLength(45);
		}
		#endregion

	}
}

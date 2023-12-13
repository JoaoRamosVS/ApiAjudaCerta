using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Drawing;
using ApiAjudaCerta.Models;
using ApiAjudaCerta.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAjudaCerta.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)  : base(options)
        {
            
        }

        public DbSet<Usuario> Usuario { get; set;}
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Doacao> Doacao { get; set; }
        public DbSet<ItemDoacao> ItemDoacao { get; set;}
        public DbSet<Roupa> Roupa { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Mobilia> Mobilia { get; set; }
        public DbSet<Eletrodomestico> Eletrodomestico { get; set; }
        public DbSet<ItemDoacaoDoado> ItemDoacaoDoado { get; set; }
        public DbSet<Mensagem> Mensagem { get; set; }
        public DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemDoacaoDoado>()
                .HasKey(idd => new {idd.DoacaoId, idd.ItemDoacaoId});

            modelBuilder.Entity<Mensagem>()
                .HasOne(x => x.Remetente)
                .WithMany(x => x.MensagensRecebidas)
                .HasForeignKey(x => x.RemetenteId);

            modelBuilder.Entity<Mensagem>()
                .HasOne(x => x.Destinatario)
                .WithMany(x => x.MensagensEnviadas)
                .HasForeignKey(x => x.DestinatarioId);


            
            // modelBuilder.Entity<Dinheiro>()
            //     .Property(d => d.Id)
            //     .ValueGeneratedNever();

            Usuario user = new Usuario();
            user.Email = "ongestreladalva@gmail.com";
            Criptografia.CriarPasswordHash("12345678", out byte[] hash, out byte[] salt);

            user.Id = 1;
            user.Senha_Hash = hash;
            user.Senha_Salt = salt;
            user.Senha = string.Empty;

            

            modelBuilder.Entity<Usuario>().HasData(user);

            Endereco end = new Endereco();
            end.Id = 1;
            end.Rua = "Avenida Josino Vieira de Goes";
            end.Numero = "1091";
            end.Bairro = "Jardim Tremembé";
            end.Cep = "02319000";
            end.Cidade = "São Paulo";
            end.Estado = "São Paulo";

            modelBuilder.Entity<Endereco>().HasData(end);

            Pessoa p = new Pessoa();
            p.Id = 1;
            p.Nome = "ONG Estrela Dalva";
            p.Username = "@ong_estreladalva";
            p.Documento = null;
            p.fisicaJuridica = Models.Enuns.FisicaJuridicaEnum.PESSOA_JURIDICA;
            p.Telefone = null;
            p.Genero = null;
            p.DataNasc = DateTime.MinValue;
            p.Tipo = Models.Enuns.TipoPessoaEnum.ONG;
            p.EnderecoId = 1;
            p.UsuarioId = 1;
            modelBuilder.Entity<Pessoa>().HasData(p);

        }
    }
}
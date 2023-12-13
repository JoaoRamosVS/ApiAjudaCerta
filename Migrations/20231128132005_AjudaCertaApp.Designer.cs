﻿// <auto-generated />
using System;
using ApiAjudaCerta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231128132005_AjudaCertaApp")]
    partial class AjudaCertaApp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiAjudaCerta.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Doacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgendaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<double>("Dinheiro")
                        .HasColumnType("float");

                    b.Property<int>("IdDoacaoOrigem")
                        .HasColumnType("int");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("StatusDoacao")
                        .HasColumnType("int");

                    b.Property<int>("TipoDoacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId")
                        .IsUnique();

                    b.HasIndex("PessoaId");

                    b.ToTable("Doacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Eletrodomestico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Condicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemDoacaoId")
                        .HasColumnType("int");

                    b.Property<string>("Medida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusItem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemDoacaoId");

                    b.ToTable("Eletrodomestico");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bloco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bairro = "Jardim Tremembé",
                            Cep = "02319000",
                            Cidade = "São Paulo",
                            Estado = "São Paulo",
                            Numero = "1091",
                            Rua = "Avenida Josino Vieira de Goes"
                        });
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.ItemDoacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoItem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.ItemDoacaoDoado", b =>
                {
                    b.Property<int>("DoacaoId")
                        .HasColumnType("int");

                    b.Property<int>("ItemDoacaoId")
                        .HasColumnType("int");

                    b.HasKey("DoacaoId", "ItemDoacaoId");

                    b.HasIndex("ItemDoacaoId");

                    b.ToTable("ItemDoacaoDoado");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Mensagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinatarioId")
                        .HasColumnType("int");

                    b.Property<int>("RemetenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinatarioId");

                    b.HasIndex("RemetenteId");

                    b.ToTable("Mensagem");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Mobilia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Condicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemDoacaoId")
                        .HasColumnType("int");

                    b.Property<string>("Medida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusItem")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemDoacaoId");

                    b.ToTable("Mobilia");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("fisicaJuridica")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pessoa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNasc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnderecoId = 1,
                            Nome = "ONG Estrela Dalva",
                            Tipo = 2,
                            Username = "@ong_estreladalva",
                            UsuarioId = 1,
                            fisicaJuridica = 2
                        });
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataPostagem")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ItemDoacaoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusItem")
                        .HasColumnType("int");

                    b.Property<int>("TipoProduto")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemDoacaoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Roupa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Condicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FaixaEtaria")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int?>("ItemDoacaoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusItem")
                        .HasColumnType("int");

                    b.Property<string>("Tamanho")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemDoacaoId");

                    b.ToTable("Roupa");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Senha_Hash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Senha_Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("UltimoAcesso")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ongestreladalva@gmail.com",
                            Senha_Hash = new byte[] { 85, 219, 140, 53, 102, 244, 89, 149, 134, 59, 119, 55, 100, 218, 29, 0, 38, 15, 89, 231, 18, 86, 69, 59, 38, 124, 61, 222, 253, 134, 44, 210, 46, 137, 183, 134, 108, 5, 44, 211, 94, 144, 62, 254, 116, 239, 63, 59, 1, 129, 76, 37, 107, 201, 139, 118, 128, 139, 251, 111, 242, 123, 53, 1 },
                            Senha_Salt = new byte[] { 176, 110, 23, 179, 89, 112, 129, 83, 93, 105, 220, 102, 1, 131, 146, 38, 36, 196, 47, 14, 233, 167, 114, 13, 159, 101, 147, 247, 195, 152, 54, 251, 211, 228, 3, 188, 174, 156, 55, 198, 1, 142, 56, 218, 81, 187, 174, 46, 116, 79, 252, 18, 130, 193, 42, 122, 153, 198, 203, 221, 10, 137, 125, 83, 254, 235, 184, 108, 248, 62, 148, 90, 105, 239, 126, 102, 82, 61, 241, 217, 238, 92, 106, 140, 124, 255, 104, 220, 76, 79, 203, 241, 222, 249, 184, 49, 8, 245, 175, 191, 213, 195, 62, 235, 216, 29, 110, 184, 44, 104, 126, 151, 64, 67, 120, 131, 191, 250, 195, 57, 243, 201, 127, 232, 43, 24, 197, 18 },
                            UltimoAcesso = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Agenda", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Endereco", "Endereco")
                        .WithMany("Agendas")
                        .HasForeignKey("EnderecoId");

                    b.HasOne("ApiAjudaCerta.Models.Pessoa", "Pessoa")
                        .WithMany("Agendas")
                        .HasForeignKey("PessoaId");

                    b.Navigation("Endereco");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Doacao", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Agenda", "Agenda")
                        .WithOne("Doacao")
                        .HasForeignKey("ApiAjudaCerta.Models.Doacao", "AgendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiAjudaCerta.Models.Pessoa", "Pessoa")
                        .WithMany("Doacoes")
                        .HasForeignKey("PessoaId");

                    b.Navigation("Agenda");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Eletrodomestico", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.ItemDoacao", "ItemDoacao")
                        .WithMany("Eletrodomesticos")
                        .HasForeignKey("ItemDoacaoId");

                    b.Navigation("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.ItemDoacaoDoado", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Doacao", "Doacao")
                        .WithMany("ItemDoacaoDoados")
                        .HasForeignKey("DoacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiAjudaCerta.Models.ItemDoacao", "ItemDoacao")
                        .WithMany("ItemDoacaoDoados")
                        .HasForeignKey("ItemDoacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doacao");

                    b.Navigation("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Mensagem", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Pessoa", "Destinatario")
                        .WithMany("MensagensEnviadas")
                        .HasForeignKey("DestinatarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiAjudaCerta.Models.Pessoa", "Remetente")
                        .WithMany("MensagensRecebidas")
                        .HasForeignKey("RemetenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destinatario");

                    b.Navigation("Remetente");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Mobilia", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.ItemDoacao", "ItemDoacao")
                        .WithMany("Mobilias")
                        .HasForeignKey("ItemDoacaoId");

                    b.Navigation("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Pessoa", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Endereco", "Endereco")
                        .WithMany("Pessoa")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiAjudaCerta.Models.Usuario", "Usuario")
                        .WithMany("Pessoas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Produto", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.ItemDoacao", "ItemDoacao")
                        .WithMany("Produtos")
                        .HasForeignKey("ItemDoacaoId");

                    b.Navigation("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Roupa", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.ItemDoacao", "ItemDoacao")
                        .WithMany("Roupas")
                        .HasForeignKey("ItemDoacaoId");

                    b.Navigation("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Agenda", b =>
                {
                    b.Navigation("Doacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Doacao", b =>
                {
                    b.Navigation("ItemDoacaoDoados");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Endereco", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.ItemDoacao", b =>
                {
                    b.Navigation("Eletrodomesticos");

                    b.Navigation("ItemDoacaoDoados");

                    b.Navigation("Mobilias");

                    b.Navigation("Produtos");

                    b.Navigation("Roupas");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Pessoa", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Doacoes");

                    b.Navigation("MensagensEnviadas");

                    b.Navigation("MensagensRecebidas");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Usuario", b =>
                {
                    b.Navigation("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}

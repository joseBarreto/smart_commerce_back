﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartCommerce.Infra.Data.Context;

namespace SmartCommerce.Infra.Data.Migrations
{
    [DbContext(typeof(SmartCommerceContext))]
    [Migration("20210921002602_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartCommerce.Domain.Entities.Local", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BAIRRO");

                    b.Property<int>("Cep")
                        .HasColumnType("int")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CIDADE");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("COMPLEMENTO");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_CADASTRO");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IMAGEM_URL");

                    b.Property<double>("Latitude")
                        .HasColumnType("float")
                        .HasColumnName("LATITUDE");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LOGRADOURO");

                    b.Property<double>("Longitude")
                        .HasColumnType("float")
                        .HasColumnName("LONGITUDE");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME");

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasColumnName("NUMERO");

                    b.Property<int>("SegmentoId")
                        .HasColumnType("int")
                        .HasColumnName("SEGMENTOID");

                    b.Property<int?>("TotalVotacao")
                        .HasColumnType("int")
                        .HasColumnName("TOTAL_VOTACAO");

                    b.Property<string>("Uf")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("UF");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("USUARIOID");

                    b.HasKey("Id");

                    b.HasIndex("SegmentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("T_LOCAL");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.LocalProduto", b =>
                {
                    b.Property<int>("LocalId")
                        .HasColumnType("int")
                        .HasColumnName("LOCALID");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int")
                        .HasColumnName("PRODUTOID");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_CADASTRO");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("LocalId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("T_LOCAL_PRODUTO");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataUltimoAcesso")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_ULTIMO_ACESSO");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SENHA");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("USUARIOID");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("T_LOGIN");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnType("int")
                        .HasColumnName("CODIGO");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_CADASTRO");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME");

                    b.Property<double>("PrecoEstimado")
                        .HasColumnType("float")
                        .HasColumnName("PRECO_ESTIMADO");

                    b.HasKey("Id");

                    b.ToTable("T_PRODUTO");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.Segmento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnType("int")
                        .HasColumnName("CODIGO");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_CADASTRO");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("IconeNome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ICONE_NOME");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.ToTable("T_SEGMENTO");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_CADASTRO");

                    b.Property<bool>("Empresa")
                        .HasColumnType("bit")
                        .HasColumnName("EMPRESA");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SOBRENOME");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.ToTable("T_USUARIO");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.Votacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_CADASTRO");

                    b.Property<int>("LocalId")
                        .HasColumnType("int")
                        .HasColumnName("LOCALID");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("USUARIOID");

                    b.Property<bool>("Voto")
                        .HasColumnType("bit")
                        .HasColumnName("VOTO");

                    b.HasKey("Id");

                    b.ToTable("T_VOTACAO");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.Local", b =>
                {
                    b.HasOne("SmartCommerce.Domain.Entities.Segmento", "Segmento")
                        .WithMany()
                        .HasForeignKey("SegmentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCommerce.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Segmento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.LocalProduto", b =>
                {
                    b.HasOne("SmartCommerce.Domain.Entities.Local", "Local")
                        .WithMany("LocalProdutos")
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCommerce.Domain.Entities.Produto", "Produto")
                        .WithMany("LocalProdutos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Local");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.Login", b =>
                {
                    b.HasOne("SmartCommerce.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.Local", b =>
                {
                    b.Navigation("LocalProdutos");
                });

            modelBuilder.Entity("SmartCommerce.Domain.Entities.Produto", b =>
                {
                    b.Navigation("LocalProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}

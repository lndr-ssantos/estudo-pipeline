﻿// <auto-generated />
using System;
using GerenciamentoRestaurante.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciamentoRestaurante.Infra.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.ItemCardapio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnidade")
                        .HasColumnType("decimal(4,2)");

                    b.HasKey("Id");

                    b.ToTable("ItensCardapio", (string)null);
                });

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GarcomId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal?>("ValorGorjeta")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("GarcomId");

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.PedidoItem", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<ushort>("Quantidade")
                        .HasColumnType("smallint unsigned");

                    b.HasKey("PedidoId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("PedidosItens", (string)null);
                });

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Tipo")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pessoas", (string)null);
                });

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("GerenciamentoRestaurante.Domain.Entities.Pessoa", "Garcom")
                        .WithMany("Pedidos")
                        .HasForeignKey("GarcomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Garcom");
                });

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.PedidoItem", b =>
                {
                    b.HasOne("GerenciamentoRestaurante.Domain.Entities.ItemCardapio", "ItemCardapio")
                        .WithMany("PedidoItens")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GerenciamentoRestaurante.Domain.Entities.Pedido", "Pedido")
                        .WithMany("PedidoItens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCardapio");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("GerenciamentoRestaurante.Domain.Entities.Pessoa", "Pessoa")
                        .WithOne("Usuario")
                        .HasForeignKey("GerenciamentoRestaurante.Domain.Entities.Usuario", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.ItemCardapio", b =>
                {
                    b.Navigation("PedidoItens");
                });

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("PedidoItens");
                });

            modelBuilder.Entity("GerenciamentoRestaurante.Domain.Entities.Pessoa", b =>
                {
                    b.Navigation("Pedidos");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}

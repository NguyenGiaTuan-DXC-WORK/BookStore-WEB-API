﻿// <auto-generated />
using System;
using BookStoreMVC.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreMVC.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240108052850_AddDetailBookConfiguration")]
    partial class AddDetailBookConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreMVC.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("date")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int?>("IdSerie")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SerieId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStoreMVC.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("category_name");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("date")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("BookStoreMVC.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("date")
                        .HasColumnName("created_date");

                    b.Property<int?>("IdBook")
                        .HasColumnType("int")
                        .HasColumnName("id_book");

                    b.Property<string>("ImageName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("image_named");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("IdBook");

                    b.ToTable("images", (string)null);
                });

            modelBuilder.Entity("BookStoreMVC.Models.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("date")
                        .HasColumnName("created_date");

                    b.Property<int>("EndYear")
                        .HasColumnType("int")
                        .HasColumnName("end_year");

                    b.Property<string>("SerieName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("serie_name");

                    b.Property<int>("StartYear")
                        .HasColumnType("int")
                        .HasColumnName("start_year");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.ToTable("series", (string)null);
                });

            modelBuilder.Entity("BookStoreMVC.Models.Book", b =>
                {
                    b.HasOne("BookStoreMVC.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreMVC.Models.Serie", "Serie")
                        .WithMany("Books")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("BookStoreMVC.Models.Image", b =>
                {
                    b.HasOne("BookStoreMVC.Models.Book", "Book")
                        .WithMany("Images")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_IMAGES_BOOK");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStoreMVC.Models.Book", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("BookStoreMVC.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStoreMVC.Models.Serie", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}

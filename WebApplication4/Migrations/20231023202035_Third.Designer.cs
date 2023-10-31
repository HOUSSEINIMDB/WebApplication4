﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication4.Data;

#nullable disable

namespace WebApplication4.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231023202035_Third")]
    partial class Third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.23");

            modelBuilder.Entity("WebApplication4.Model.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("WebApplication4.Model.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GameDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GameTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WebApplication4.Model.GameItem", b =>
                {
                    b.Property<string>("ItemId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CartId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("GameId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WebApplication4.Model.GameItem", b =>
                {
                    b.HasOne("WebApplication4.Model.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartId");

                    b.HasOne("WebApplication4.Model.Game", null)
                        .WithMany("GameItems")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("WebApplication4.Model.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("WebApplication4.Model.Game", b =>
                {
                    b.Navigation("GameItems");
                });
#pragma warning restore 612, 618
        }
    }
}
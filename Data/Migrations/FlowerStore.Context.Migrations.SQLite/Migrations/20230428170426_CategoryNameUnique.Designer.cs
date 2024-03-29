﻿// <auto-generated />
using System;
using FlowerStore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlowerStore.Context.Migrations.SQLite.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20230428170426_CategoryNameUnique")]
    partial class CategoryNameUnique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("BouquetCategory", b =>
                {
                    b.Property<int>("BouquetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BouquetId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("BouquetCategory");
                });

            modelBuilder.Entity("BouquetFlower", b =>
                {
                    b.Property<int>("BouquetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FlowersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BouquetId", "FlowersId");

                    b.HasIndex("FlowersId");

                    b.ToTable("BouquetFlower");
                });

            modelBuilder.Entity("CategoryFlower", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FlowerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoriesId", "FlowerId");

                    b.HasIndex("FlowerId");

                    b.ToTable("CategoryFlower");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BouquetId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FlowerCount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FlowerId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Uid")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BouquetId");

                    b.HasIndex("FlowerId");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.Bouquet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Desription")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Uid")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bouquets");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Uid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.Flower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Price")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Uid")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Flowers");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Uid")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BouquetId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FlowerCount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FlowerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Uid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BouquetId");

                    b.HasIndex("FlowerId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("BLOB");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("BouquetCategory", b =>
                {
                    b.HasOne("FlowerStore.Context.Entities.Bouquet", null)
                        .WithMany()
                        .HasForeignKey("BouquetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlowerStore.Context.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BouquetFlower", b =>
                {
                    b.HasOne("FlowerStore.Context.Entities.Bouquet", null)
                        .WithMany()
                        .HasForeignKey("BouquetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlowerStore.Context.Entities.Flower", null)
                        .WithMany()
                        .HasForeignKey("FlowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryFlower", b =>
                {
                    b.HasOne("FlowerStore.Context.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlowerStore.Context.Entities.Flower", null)
                        .WithMany()
                        .HasForeignKey("FlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.Basket", b =>
                {
                    b.HasOne("FlowerStore.Context.Entities.Bouquet", "Bouquet")
                        .WithMany()
                        .HasForeignKey("BouquetId");

                    b.HasOne("FlowerStore.Context.Entities.Flower", "Flower")
                        .WithMany()
                        .HasForeignKey("FlowerId");

                    b.HasOne("FlowerStore.Context.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Bouquet");

                    b.Navigation("Flower");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.Bouquet", b =>
                {
                    b.HasOne("FlowerStore.Context.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.Flower", b =>
                {
                    b.HasOne("FlowerStore.Context.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.Order", b =>
                {
                    b.HasOne("FlowerStore.Context.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.OrderItem", b =>
                {
                    b.HasOne("FlowerStore.Context.Entities.Bouquet", "Bouquet")
                        .WithMany()
                        .HasForeignKey("BouquetId");

                    b.HasOne("FlowerStore.Context.Entities.Flower", "Flower")
                        .WithMany()
                        .HasForeignKey("FlowerId");

                    b.HasOne("FlowerStore.Context.Entities.Order", "Order")
                        .WithMany("OrederItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("Bouquet");

                    b.Navigation("Flower");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.UserRole", b =>
                {
                    b.HasOne("FlowerStore.Context.Entities.User", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.Order", b =>
                {
                    b.Navigation("OrederItems");
                });

            modelBuilder.Entity("FlowerStore.Context.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}

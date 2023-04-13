﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using inzOprogramowania.DataContext;

#nullable disable

namespace inzOprogramowania.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230413134326_inital")]
    partial class Inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("inzOprogramowania.Modeles.Ads", b =>
                {
                    b.Property<long>("AdsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AdsId"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiredTime")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("AdsId");

                    b.HasIndex("UserId");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("inzOprogramowania.Modeles.Comments", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CommentId"));

                    b.Property<long>("AdsId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("CommentId");

                    b.HasIndex("AdsId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("inzOprogramowania.Modeles.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("inzOprogramowania.Modeles.Ads", b =>
                {
                    b.HasOne("inzOprogramowania.Modeles.User", "User")
                        .WithMany("Ads")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("inzOprogramowania.Modeles.Comments", b =>
                {
                    b.HasOne("inzOprogramowania.Modeles.Ads", "Ads")
                        .WithMany("Comments")
                        .HasForeignKey("AdsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("inzOprogramowania.Modeles.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Ads");

                    b.Navigation("User");
                });

            modelBuilder.Entity("inzOprogramowania.Modeles.Ads", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("inzOprogramowania.Modeles.User", b =>
                {
                    b.Navigation("Ads");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
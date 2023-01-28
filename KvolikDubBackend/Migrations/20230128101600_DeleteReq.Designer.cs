﻿// <auto-generated />
using System;
using System.Collections.Generic;
using KvolikDubBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KvolikDubBackend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230128101600_DeleteReq")]
    partial class DeleteReq
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.AnimeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AgeLimit")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<int?>("EpisodesAmount")
                        .HasColumnType("integer");

                    b.Property<int>("ExitStatus")
                        .HasColumnType("integer");

                    b.Property<List<string>>("Frames")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<string>>("Genres")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PrimarySource")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReleaseBy")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ReleaseFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserEntityId")
                        .HasColumnType("uuid");

                    b.Property<int>("VoiceoverStatus")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.BadWordEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BadWords");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.RatingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnimeId")
                        .HasColumnType("uuid");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.ReviewEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnimeId")
                        .HasColumnType("uuid");

                    b.Property<int>("Likes")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.TokenEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AvatarImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("ReviewEntityId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReviewEntityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.AnimeEntity", b =>
                {
                    b.HasOne("KvolikDubBackend.Models.Entities.UserEntity", null)
                        .WithMany("FavoriteAnimes")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.RatingEntity", b =>
                {
                    b.HasOne("KvolikDubBackend.Models.Entities.AnimeEntity", "Anime")
                        .WithMany("Ratings")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KvolikDubBackend.Models.Entities.UserEntity", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.ReviewEntity", b =>
                {
                    b.HasOne("KvolikDubBackend.Models.Entities.AnimeEntity", "Anime")
                        .WithMany("Reviews")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KvolikDubBackend.Models.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.UserEntity", b =>
                {
                    b.HasOne("KvolikDubBackend.Models.Entities.ReviewEntity", null)
                        .WithMany("LikedUsers")
                        .HasForeignKey("ReviewEntityId");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.AnimeEntity", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.ReviewEntity", b =>
                {
                    b.Navigation("LikedUsers");
                });

            modelBuilder.Entity("KvolikDubBackend.Models.Entities.UserEntity", b =>
                {
                    b.Navigation("FavoriteAnimes");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}

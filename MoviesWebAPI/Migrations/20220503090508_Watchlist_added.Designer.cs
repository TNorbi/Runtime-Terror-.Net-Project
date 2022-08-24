﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesWebAPI.Data;

#nullable disable

namespace MoviesWebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220503090508_Watchlist_added")]
    partial class Watchlist_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GenresMovies", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMov_Id")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MoviesMov_Id");

                    b.HasIndex("MoviesMov_Id");

                    b.ToTable("GenresMovies");
                });

            modelBuilder.Entity("MoviesUsers", b =>
                {
                    b.Property<int>("MoviesMov_Id")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("MoviesMov_Id", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("Watchlist", (string)null);
                });

            modelBuilder.Entity("MoviesWebAPI.Data.Models.Genres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MoviesWebAPI.Data.Models.Movies", b =>
                {
                    b.Property<int>("Mov_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Mov_Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfRatings")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RunTime")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Mov_Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesWebAPI.Data.Models.Ratings", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("Mov_Id")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("UserId", "Mov_Id");

                    b.HasIndex("Mov_Id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("MoviesWebAPI.Data.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GenresMovies", b =>
                {
                    b.HasOne("MoviesWebAPI.Data.Models.Genres", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesWebAPI.Data.Models.Movies", null)
                        .WithMany()
                        .HasForeignKey("MoviesMov_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesUsers", b =>
                {
                    b.HasOne("MoviesWebAPI.Data.Models.Movies", null)
                        .WithMany()
                        .HasForeignKey("MoviesMov_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesWebAPI.Data.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesWebAPI.Data.Models.Ratings", b =>
                {
                    b.HasOne("MoviesWebAPI.Data.Models.Movies", "Movie")
                        .WithMany("UserRating")
                        .HasForeignKey("Mov_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesWebAPI.Data.Models.Users", "User")
                        .WithMany("UserRating")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesWebAPI.Data.Models.Movies", b =>
                {
                    b.Navigation("UserRating");
                });

            modelBuilder.Entity("MoviesWebAPI.Data.Models.Users", b =>
                {
                    b.Navigation("UserRating");
                });
#pragma warning restore 612, 618
        }
    }
}

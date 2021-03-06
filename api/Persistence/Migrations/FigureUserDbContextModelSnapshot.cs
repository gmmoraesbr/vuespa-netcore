﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Persistence;
using System;

namespace Persistence.Migrations
{
    [DbContext(typeof(FigureUserDbContext))]
    partial class FigureUserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Figure", b =>
                {
                    b.Property<int>("FigureId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("Number");

                    b.Property<int>("UserId");

                    b.HasKey("FigureId");

                    b.HasIndex("UserId");

                    b.ToTable("Figure");
                });

            modelBuilder.Entity("Model.FigureUser", b =>
                {
                    b.Property<int>("FigureUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FigureOwnerId");

                    b.Property<int>("FigureRequestId");

                    b.Property<int>("NumberOwner");

                    b.Property<int>("NumberRequest");

                    b.Property<string>("Status");

                    b.Property<int>("UserOwnerId");

                    b.Property<int>("UserRequestId");

                    b.HasKey("FigureUserId");

                    b.HasIndex("FigureOwnerId");

                    b.HasIndex("FigureRequestId");

                    b.HasIndex("UserOwnerId");

                    b.HasIndex("UserRequestId");

                    b.ToTable("FigureUser");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FigureExchangeTotal");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.Figure", b =>
                {
                    b.HasOne("Model.User", "User")
                        .WithMany("Figure")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.FigureUser", b =>
                {
                    b.HasOne("Model.Figure", "FigureOwner")
                        .WithMany("FigureOwner")
                        .HasForeignKey("FigureOwnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Model.Figure", "FigureRequest")
                        .WithMany("FigureRequest")
                        .HasForeignKey("FigureRequestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Model.User", "UserOwner")
                        .WithMany("FigureUserOwner")
                        .HasForeignKey("UserOwnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Model.User", "UserRequest")
                        .WithMany("FigureUserRequest")
                        .HasForeignKey("UserRequestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

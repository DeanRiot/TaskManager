﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaskManager.Model.Repository.EntityFramework.Context;

namespace TaskManager.Migrations
{
    [DbContext(typeof(TaskmanContext))]
    partial class TaskmanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Auth", b =>
                {
                    b.Property<long>("AuthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("login")
                        .HasColumnType("text");

                    b.HasKey("AuthId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Auth");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Board", b =>
                {
                    b.Property<long>("BoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("BoardId");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("CommentId");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Responsibility", b =>
                {
                    b.Property<long>("ResponsibilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.HasKey("ResponsibilityId");

                    b.ToTable("Responsibility");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Section", b =>
                {
                    b.Property<long>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<long>("BoardId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("SectionId");

                    b.HasIndex("BoardId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Task", b =>
                {
                    b.Property<long>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("ResponsibilityId")
                        .HasColumnType("bigint");

                    b.Property<long>("SectionID")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<long>("TrackId")
                        .HasColumnType("bigint");

                    b.HasKey("TaskId");

                    b.HasIndex("ResponsibilityId");

                    b.HasIndex("SectionID");

                    b.HasIndex("TrackId")
                        .IsUnique();

                    b.ToTable("Task");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Token", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("AuthId")
                        .HasColumnType("bigint");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("TokenId");

                    b.HasIndex("AuthId");

                    b.HasIndex("UserId");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Track", b =>
                {
                    b.Property<long>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Opertion")
                        .HasColumnType("text");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("TrackId");

                    b.HasIndex("UserId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long?>("ResponsibilityId")
                        .HasColumnType("bigint");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("ResponsibilityId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Auth", b =>
                {
                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.User", "User")
                        .WithOne("Auth")
                        .HasForeignKey("TaskManager.Model.Repository.EntityFramework.Context.Auth", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Comment", b =>
                {
                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Section", b =>
                {
                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.Board", "Board")
                        .WithMany("Sections")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Task", b =>
                {
                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.Responsibility", null)
                        .WithMany("Task")
                        .HasForeignKey("ResponsibilityId");

                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.Section", "Section")
                        .WithMany("Tasks")
                        .HasForeignKey("SectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.Track", "Track")
                        .WithOne("Task")
                        .HasForeignKey("TaskManager.Model.Repository.EntityFramework.Context.Task", "TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Token", b =>
                {
                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.Auth", null)
                        .WithMany("Token")
                        .HasForeignKey("AuthId");

                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Track", b =>
                {
                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.User", b =>
                {
                    b.HasOne("TaskManager.Model.Repository.EntityFramework.Context.Responsibility", null)
                        .WithMany("User")
                        .HasForeignKey("ResponsibilityId");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Auth", b =>
                {
                    b.Navigation("Token");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Board", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Responsibility", b =>
                {
                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Section", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.Track", b =>
                {
                    b.Navigation("Task");
                });

            modelBuilder.Entity("TaskManager.Model.Repository.EntityFramework.Context.User", b =>
                {
                    b.Navigation("Auth");
                });
#pragma warning restore 612, 618
        }
    }
}
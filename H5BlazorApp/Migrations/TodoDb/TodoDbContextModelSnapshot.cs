﻿// <auto-generated />
using H5BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace H5BlazorApp.Migrations.TodoDb
{
    [DbContext(typeof(TodoDbContext))]
    partial class TodoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("H5BlazorApp.Data.Model.Cpr", b =>
                {
                    b.Property<int>("CprId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CprId"));

                    b.Property<string>("CprNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CprId");

                    b.ToTable("Cpr");
                });

            modelBuilder.Entity("H5BlazorApp.Data.Model.Todolist", b =>
                {
                    b.Property<int>("TodolistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TodolistId"));

                    b.Property<int>("CprId")
                        .HasColumnType("int");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("TodolistId");

                    b.HasIndex("CprId");

                    b.ToTable("Todolist");
                });

            modelBuilder.Entity("H5BlazorApp.Data.Model.Todolist", b =>
                {
                    b.HasOne("H5BlazorApp.Data.Model.Cpr", "Cpr")
                        .WithMany()
                        .HasForeignKey("CprId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cpr");
                });
#pragma warning restore 612, 618
        }
    }
}

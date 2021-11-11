﻿// <auto-generated />
using ExamAutomation.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamAutomation.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211107152348_exams_v1")]
    partial class exams_v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ExamAutomation.Domain.Models.Exams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Title")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}
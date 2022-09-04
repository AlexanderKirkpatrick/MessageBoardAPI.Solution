﻿// <auto-generated />
using System;
using MessageBoardAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageBoardAPI.Migrations
{
    [DbContext(typeof(MessageBoardAPIContext))]
    partial class MessageBoardAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MessageBoardAPI.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            Author = "Mark",
                            Date = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This is a test message",
                            Group = "TEST"
                        },
                        new
                        {
                            MessageId = 2,
                            Author = "Mark",
                            Date = new DateTime(2022, 1, 1, 10, 10, 10, 0, DateTimeKind.Unspecified),
                            Description = "This is a test message",
                            Group = "TEST 1"
                        },
                        new
                        {
                            MessageId = 3,
                            Author = "Mark",
                            Date = new DateTime(2022, 1, 1, 10, 10, 10, 0, DateTimeKind.Unspecified),
                            Description = "This is a test message",
                            Group = "TEST"
                        },
                        new
                        {
                            MessageId = 4,
                            Author = "Jack",
                            Date = new DateTime(2022, 1, 1, 10, 10, 10, 0, DateTimeKind.Unspecified),
                            Description = "This is a test message",
                            Group = "TEST 1"
                        },
                        new
                        {
                            MessageId = 5,
                            Author = "Jack",
                            Date = new DateTime(2022, 1, 1, 10, 10, 10, 0, DateTimeKind.Unspecified),
                            Description = "This is a test message",
                            Group = "TEST"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

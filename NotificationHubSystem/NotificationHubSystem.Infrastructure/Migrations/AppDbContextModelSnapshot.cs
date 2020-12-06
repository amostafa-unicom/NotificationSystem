﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationHubSystem.Infrastructure.Context;

namespace NotificationHubSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.Mail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BCC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHtml")
                        .HasColumnType("bit");

                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId")
                        .IsUnique();

                    b.ToTable("Mail");
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.NotificationBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("DeleteStatus")
                        .HasColumnType("int");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeId");

                    b.ToTable("NotificationBase");
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.NotificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeleteStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NotificationType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2020, 12, 6, 21, 31, 43, 932, DateTimeKind.Local).AddTicks(1702),
                            DeleteStatus = 0,
                            Name = "Mail"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2020, 12, 6, 21, 31, 43, 932, DateTimeKind.Local).AddTicks(2427),
                            DeleteStatus = 0,
                            Name = "PushNotification"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2020, 12, 6, 21, 31, 43, 932, DateTimeKind.Local).AddTicks(2589),
                            DeleteStatus = 0,
                            Name = "SMS"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2020, 12, 6, 21, 31, 43, 932, DateTimeKind.Local).AddTicks(2701),
                            DeleteStatus = 0,
                            Name = "RealTime"
                        });
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.PushNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.Property<string>("NotificationTokenId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SendData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId")
                        .IsUnique();

                    b.ToTable("PushNotification");
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.RealTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId")
                        .IsUnique();

                    b.ToTable("RealTime");
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.SMS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.Property<string>("Recipient")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId")
                        .IsUnique();

                    b.ToTable("SMS");
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.SendingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("DeleteStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SendingStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2020, 12, 6, 21, 31, 43, 927, DateTimeKind.Local).AddTicks(1503),
                            DeleteStatus = 0,
                            Name = "New"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2020, 12, 6, 21, 31, 43, 931, DateTimeKind.Local).AddTicks(5989),
                            DeleteStatus = 0,
                            Name = "Success"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2020, 12, 6, 21, 31, 43, 931, DateTimeKind.Local).AddTicks(6493),
                            DeleteStatus = 0,
                            Name = "Failed"
                        });
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.Mail", b =>
                {
                    b.HasOne("NotificationHubSystem.Core.Entities.NotificationBase", "NotificationBase")
                        .WithOne("Mail")
                        .HasForeignKey("NotificationHubSystem.Core.Entities.Mail", "NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.NotificationBase", b =>
                {
                    b.HasOne("NotificationHubSystem.Core.Entities.SendingStatus", "SendingStatus")
                        .WithMany("NotificationBase")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NotificationHubSystem.Core.Entities.NotificationType", "NotificationType")
                        .WithMany("NotificationBase")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.PushNotification", b =>
                {
                    b.HasOne("NotificationHubSystem.Core.Entities.NotificationBase", "NotificationBase")
                        .WithOne("PushNotification")
                        .HasForeignKey("NotificationHubSystem.Core.Entities.PushNotification", "NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.RealTime", b =>
                {
                    b.HasOne("NotificationHubSystem.Core.Entities.NotificationBase", "NotificationBase")
                        .WithOne("RealTime")
                        .HasForeignKey("NotificationHubSystem.Core.Entities.RealTime", "NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NotificationHubSystem.Core.Entities.SMS", b =>
                {
                    b.HasOne("NotificationHubSystem.Core.Entities.NotificationBase", "NotificationBase")
                        .WithOne("SMS")
                        .HasForeignKey("NotificationHubSystem.Core.Entities.SMS", "NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

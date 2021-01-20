﻿// <auto-generated />
using ArmyRosterAPI.AccessDataBases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArmyRosterAPI.Migrations
{
    [DbContext(typeof(ArmyRosterContext))]
    partial class ArmyRosterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ArmyRosterAPI.Models.Roster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ArmyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Rosters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmyName = "Strongers Army Ever",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ArmyRosterAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Poznan",
                            Email = "email",
                            FirstName = "Bartosz",
                            SecondName = "Bednarek"
                        });
                });

            modelBuilder.Entity("ArmyRosterAPI.Models.Roster", b =>
                {
                    b.HasOne("ArmyRosterAPI.Models.User", "User")
                        .WithOne("Roster")
                        .HasForeignKey("ArmyRosterAPI.Models.Roster", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ArmyRosterAPI.Models.User", b =>
                {
                    b.Navigation("Roster");
                });
#pragma warning restore 612, 618
        }
    }
}
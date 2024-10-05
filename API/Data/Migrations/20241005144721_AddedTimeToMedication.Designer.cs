﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241005144721_AddedTimeToMedication")]
    partial class AddedTimeToMedication
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.HeartRate", b =>
                {
                    b.Property<int>("HeartRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Measurement")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HeartRateId");

                    b.HasIndex("UserId");

                    b.ToTable("HeartRates");
                });

            modelBuilder.Entity("API.Entities.HighHeartRate", b =>
                {
                    b.Property<int>("HighHeartRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Confirm")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Measurement")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("TimeOfConfirmation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HighHeartRateId");

                    b.HasIndex("UserId");

                    b.ToTable("HighHeartRates");
                });

            modelBuilder.Entity("API.Entities.Medication", b =>
                {
                    b.Property<int>("MedicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RepeatingPattern")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("TimeOfDay")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MedicationId");

                    b.HasIndex("UserId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("API.Entities.MedicationIntake", b =>
                {
                    b.Property<int>("MedicationIntakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedicationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Taken")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MedicationIntakeId");

                    b.HasIndex("MedicationId");

                    b.HasIndex("UserId");

                    b.ToTable("MedicationIntakes");
                });

            modelBuilder.Entity("API.Entities.SuddenMovement", b =>
                {
                    b.Property<int>("MovementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Confirm")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("TimeOfConfirmation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovementId");

                    b.HasIndex("UserId");

                    b.ToTable("SuddenMovements");
                });

            modelBuilder.Entity("API.Entities.HeartRate", b =>
                {
                    b.HasOne("API.Entities.AppUser", "User")
                        .WithMany("HeartRates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.HighHeartRate", b =>
                {
                    b.HasOne("API.Entities.AppUser", "User")
                        .WithMany("HighHeartRates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.Medication", b =>
                {
                    b.HasOne("API.Entities.AppUser", "User")
                        .WithMany("Medications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.MedicationIntake", b =>
                {
                    b.HasOne("API.Entities.Medication", "Medication")
                        .WithMany("MedicationIntakes")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.AppUser", "User")
                        .WithMany("MedicationIntakes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medication");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.SuddenMovement", b =>
                {
                    b.HasOne("API.Entities.AppUser", "User")
                        .WithMany("SuddenMovements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("HeartRates");

                    b.Navigation("HighHeartRates");

                    b.Navigation("MedicationIntakes");

                    b.Navigation("Medications");

                    b.Navigation("SuddenMovements");
                });

            modelBuilder.Entity("API.Entities.Medication", b =>
                {
                    b.Navigation("MedicationIntakes");
                });
#pragma warning restore 612, 618
        }
    }
}

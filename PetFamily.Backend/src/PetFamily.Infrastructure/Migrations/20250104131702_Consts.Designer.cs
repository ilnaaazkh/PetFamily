﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetFamily.Infrastructure;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250104131702_Consts")]
    partial class Consts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetFamily.Domain.Species.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.Property<Guid?>("species_id")
                        .HasColumnType("uuid")
                        .HasColumnName("species_id");

                    b.HasKey("Id")
                        .HasName("pk_breeds");

                    b.HasIndex("species_id")
                        .HasDatabaseName("ix_breeds_species_id");

                    b.ToTable("breeds", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Species.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_species");

                    b.ToTable("species", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Volunteers.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("color");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("OwnerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("owner_phone_number");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<Guid?>("volunteer_id")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.ComplexProperty<Dictionary<string, object>>("PetType", "PetFamily.Domain.Volunteers.Pet.PetType#PetType", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("BreedId")
                                .HasColumnType("uuid")
                                .HasColumnName("breeed_id");

                            b1.Property<Guid>("SpeciesId")
                                .HasColumnType("uuid")
                                .HasColumnName("species_id");
                        });

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("volunteer_id")
                        .HasDatabaseName("ix_pets_volunteer_id");

                    b.ToTable("pets", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Volunteers.Volunteers", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<int>("WorkExperienceInYears")
                        .HasColumnType("integer")
                        .HasColumnName("work_experience_in_years");

                    b.ComplexProperty<Dictionary<string, object>>("FullName", "PetFamily.Domain.Volunteers.Volunteers.FullName#FullName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("last_name");

                            b1.Property<string>("MiddleName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("middle_name");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("volunteers", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Species.Breed", b =>
                {
                    b.HasOne("PetFamily.Domain.Species.Species", null)
                        .WithMany("Breeds")
                        .HasForeignKey("species_id")
                        .HasConstraintName("fk_breeds_species_species_id");
                });

            modelBuilder.Entity("PetFamily.Domain.Volunteers.Pet", b =>
                {
                    b.HasOne("PetFamily.Domain.Volunteers.Volunteers", null)
                        .WithMany("Pets")
                        .HasForeignKey("volunteer_id")
                        .HasConstraintName("fk_pets_volunteers_volunteer_id");

                    b.OwnsOne("PetFamily.Domain.Volunteers.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("country");

                            b1.Property<string>("HouseNumber")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("apartment_number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("state");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("street");

                            b1.HasKey("PetId");

                            b1.ToTable("pets");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_id");
                        });

                    b.OwnsOne("PetFamily.Domain.Volunteers.MedicalInformation", "MedicalInformation", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("HealthInformation")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("character varying(2000)")
                                .HasColumnName("medical_information_health_information");

                            b1.Property<int>("Height")
                                .HasColumnType("integer")
                                .HasColumnName("height");

                            b1.Property<bool>("IsCastrated")
                                .HasColumnType("boolean")
                                .HasColumnName("is_castrated");

                            b1.Property<bool>("IsVaccinated")
                                .HasColumnType("boolean")
                                .HasColumnName("is_vaccinated");

                            b1.Property<int>("Weight")
                                .HasColumnType("integer")
                                .HasColumnName("weight");

                            b1.HasKey("PetId");

                            b1.ToTable("pets");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_id");
                        });

                    b.OwnsOne("PetFamily.Domain.Volunteers.RequisitesList", "RequisitesList", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid");

                            b1.HasKey("PetId")
                                .HasName("pk_pets");

                            b1.ToTable("pets");

                            b1.ToJson("requisites_list");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pets_pets_pet_id");

                            b1.OwnsMany("PetFamily.Domain.Volunteers.Requisite", "Requisites", b2 =>
                                {
                                    b2.Property<Guid>("RequisitesListPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("__synthesizedOrdinal")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(2000)
                                        .HasColumnType("character varying(2000)");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.HasKey("RequisitesListPetId", "__synthesizedOrdinal");

                                    b2.ToTable("pets");

                                    b2.ToJson("requisites_list");

                                    b2.WithOwner()
                                        .HasForeignKey("RequisitesListPetId")
                                        .HasConstraintName("fk_pets_pets_requisites_list_pet_id");
                                });

                            b1.Navigation("Requisites");
                        });

                    b.Navigation("Address");

                    b.Navigation("MedicalInformation");

                    b.Navigation("RequisitesList");
                });

            modelBuilder.Entity("PetFamily.Domain.Volunteers.Volunteers", b =>
                {
                    b.OwnsOne("PetFamily.Domain.Volunteers.SocialMediaList", "SocialMediaList", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("volunteers");

                            b1.ToJson("social_media_list");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_id");

                            b1.OwnsMany("PetFamily.Domain.Volunteers.SocialMedia", "SocialMedias", b2 =>
                                {
                                    b2.Property<Guid>("SocialMediaListVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("__synthesizedOrdinal")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Link")
                                        .IsRequired()
                                        .HasMaxLength(2000)
                                        .HasColumnType("character varying(2000)");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.HasKey("SocialMediaListVolunteerId", "__synthesizedOrdinal");

                                    b2.ToTable("volunteers");

                                    b2.ToJson("social_media_list");

                                    b2.WithOwner()
                                        .HasForeignKey("SocialMediaListVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_social_media_list_volunteer_id");
                                });

                            b1.Navigation("SocialMedias");
                        });

                    b.OwnsOne("PetFamily.Domain.Volunteers.RequisitesList", "Requisites", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("volunteers");

                            b1.ToJson("requisites");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_id");

                            b1.OwnsMany("PetFamily.Domain.Volunteers.Requisite", "Requisites", b2 =>
                                {
                                    b2.Property<Guid>("RequisitesListVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("__synthesizedOrdinal")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(2000)
                                        .HasColumnType("character varying(2000)");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("character varying(100)");

                                    b2.HasKey("RequisitesListVolunteerId", "__synthesizedOrdinal");

                                    b2.ToTable("volunteers");

                                    b2.ToJson("requisites");

                                    b2.WithOwner()
                                        .HasForeignKey("RequisitesListVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_requisites_list_volunteer_id");
                                });

                            b1.Navigation("Requisites");
                        });

                    b.Navigation("Requisites");

                    b.Navigation("SocialMediaList");
                });

            modelBuilder.Entity("PetFamily.Domain.Species.Species", b =>
                {
                    b.Navigation("Breeds");
                });

            modelBuilder.Entity("PetFamily.Domain.Volunteers.Volunteers", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}

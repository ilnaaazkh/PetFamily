﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Application.Dtos;
using System.Text.Json;

namespace PetFamily.Infrastructure.Configurations.Read
{
    internal class VolunteerDtoConfiguration : IEntityTypeConfiguration<VolunteerDto>
    {
        public void Configure(EntityTypeBuilder<VolunteerDto> builder)
        {
            builder.ToTable(Tables.Volunteers);

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Requisites)
                .HasConversion(req => JsonSerializer.Serialize(string.Empty, JsonSerializerOptions.Default), 
                 json => JsonSerializer.Deserialize<RequisiteDto[]>(json, JsonSerializerOptions.Default)!);
            
            builder.Property(v => v.SocialMedias)
                .HasConversion(req => JsonSerializer.Serialize(string.Empty, JsonSerializerOptions.Default), 
                 json => JsonSerializer.Deserialize<SocialMediaDto[]>(json, JsonSerializerOptions.Default)!);
        }
    }
}

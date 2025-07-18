﻿using PetFamily.Application.Abstractions;
using PetFamily.Application.Volunteers.Commands.Shared;

namespace PetFamily.Application.Volunteers.Commands.UpdatePetInfo
{
    public record UpdatePetInfoCommand(
        Guid VolunteerId,
        Guid PetId,
        string PetName,
        Guid SpeciesId,
        Guid BreedId,
        string Description,
        string OwnerPhoneNumber,
        string Color,
        DateTime DateOfBirth,
        IEnumerable<RequisitesInfo> Requisites,
        bool IsCastrated,
        bool IsVaccinated,
        string HealthInformation,
        int Height,
        int Weight,
        string Country,
        string State,
        string City,
        string Street,
        string HouseNumber,
        int? ApartmentNumber) : ICommand;
}

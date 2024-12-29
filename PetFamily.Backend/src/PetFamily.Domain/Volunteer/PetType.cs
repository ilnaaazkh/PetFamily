﻿using CSharpFunctionalExtensions;
using PetFamily.Domain.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{
    public record PetType
    {
        private PetType(SpeciesId speciesId, BreedId breedId)
        {
            SpeciesId = speciesId;
            BreedId = breedId;
        }

        SpeciesId SpeciesId { get; }
        BreedId BreedId { get; }

        public static Result<PetType> Create(SpeciesId speciesId, BreedId breedId)
        {
            var errors = string.Empty;

            if (speciesId is null)
            {
                errors += "Species id must be provided\n";
            }

            if (breedId is null)
            {
                errors += "Breed id must be provided\n";
            }

            if (string.IsNullOrEmpty(errors))
            {
                return Result.Success(new PetType(speciesId!, breedId!));
            }

            return Result.Failure<PetType>(errors);
        }
    }
}
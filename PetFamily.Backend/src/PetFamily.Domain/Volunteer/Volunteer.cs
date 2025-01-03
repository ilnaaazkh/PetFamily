﻿using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer
{
    public class Volunteer : Entity<VolunteerId>
    {
        private readonly List<Pet> _pets = new();
        
        //ef core
        private Volunteer(VolunteerId id) : base(id)
        {
        }

        private Volunteer(VolunteerId id, FullName fullName, Email email, PhoneNumber phoneNumber) : base(id)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;  
        }

        public FullName FullName { get; private set; }
        public Email Email { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int WorkExperienceInYears { get; set; } = 0;
        public PhoneNumber PhoneNumber { get; private set; }
        public RequisitesList? Requisites { get; private set; }
        public IReadOnlyList<Pet> Pets => _pets;
        public SocialMediaList? SocialMediaList { get; private set; }

        public int PetsFoundHomeCount => _pets.Where(p => p.Status == PetStatus.FoundHome).Count();
        public int HomelessPetsCount => _pets.Where(p => p.Status == PetStatus.SearchingForHome).Count();
        public int PetsInTreatmentCount => _pets.Where(p => p.Status == PetStatus.NeedsHelp).Count();

        public static Result<Volunteer> Create(VolunteerId id, FullName fullName, Email email, PhoneNumber phoneNumber)
        {
            string errors = string.Empty;

            if(fullName is null)
            {
                errors += "Fullname must be provided";
            }

            if(email is null)
            {
                errors += "Email must be provided";
            }

            if(phoneNumber is null)
            {
                errors += "Phone number must be provided";
            }

            if (string.IsNullOrEmpty(errors))
            {
                return Result.Success(new Volunteer(id, fullName!, email!, phoneNumber!));
            }

            return Result.Failure<Volunteer>(errors);
        }
    }
}

﻿using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;


namespace PetFamily.Domain.Volunteer
{
    public class Pet : SoftDeleteableEntity<PetId>
    {
        //ef core
        private Pet(PetId id) : base(id) 
        { 
        }

        public Pet(PetId id, PetName name, PetType petType, Description description, PhoneNumber ownerPhoneNumber, PetStatus status) : base(id)
        {
            Name = name;
            PetType = petType;
            Description = description;
            OwnerPhoneNumber = ownerPhoneNumber;
            Status = status;
        }

        public PetName Name { get; private set; }

        public PetType PetType {  get; private set; }         

        public Description Description { get; private set; }

        public Color Color { get; private set; } = Color.DefaultColor;

        public MedicalInformation? MedicalInformation { get; private set; }

        public Address? Address { get; private set; }

        public PhoneNumber OwnerPhoneNumber { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public PetStatus Status { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public RequisitesList? RequisitesList { get; private set; }
    }
}

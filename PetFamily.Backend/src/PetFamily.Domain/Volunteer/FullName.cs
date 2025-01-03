﻿using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer
{
    public class FullName : ComparableValueObject
    {
        public string FirstName { get;  } 
        public string LastName { get; } 
        public string MiddleName { get; }

        private FullName(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public static Result<FullName> Create(string firstName, string lastName, string middleName)
        {
            string errors = string.Empty;

            if (string.IsNullOrWhiteSpace(firstName))
            {
                errors += "First name cannot be empty\n";
            }
            
            if (string.IsNullOrWhiteSpace(lastName))
            {
                errors += "Last name cannot be empty\n";
            }
            
            if (string.IsNullOrWhiteSpace(middleName))
            {
                errors += "Middle name cannot be empty\n";
            }

            if (string.IsNullOrWhiteSpace(errors))
            {
                return Result.Success(new FullName(firstName, lastName, middleName));
            }

            return Result.Failure<FullName>(errors);
        }

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;  
            yield return MiddleName;
        }
    }
}

﻿using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Volunteer
{
    public class PhoneNumber : ComparableValueObject
    {
        public string Value { get;  }

        private PhoneNumber(string value) 
        { 
            Value = value;
        }

        public static Result<PhoneNumber> Create(string value)
        {
            string pattern = @"^\+?\d{1,4}?[-.\s]?\d{1,4}[-.\s]?\d{1,9}$";
            
            if(Regex.IsMatch(value, pattern))
            {
                return Result.Success<PhoneNumber>(new PhoneNumber(value));
            }

            return Result.Failure<PhoneNumber>("Phone number has incorrect format");
        }

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }
    }
}

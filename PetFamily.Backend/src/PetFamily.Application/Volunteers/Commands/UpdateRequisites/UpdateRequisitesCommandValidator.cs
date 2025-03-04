﻿using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Application.Volunteers.Commands.UpdateRequisites
{
    public class UpdateRequisitesCommandValidator : AbstractValidator<UpdateRequisitesCommand>
    {
        public UpdateRequisitesCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();

            RuleForEach(c => c.Requisites).MustBeValueObject(r => Requisite.Create(r.Title, r.Description));
        }
    }
}

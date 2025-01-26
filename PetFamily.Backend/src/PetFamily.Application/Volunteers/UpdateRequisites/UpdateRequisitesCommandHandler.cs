﻿
using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Application.Volunteers.UpdateRequisites
{
    public class UpdateRequisitesCommandHandler 
    {
        private readonly IVolunteersRepository _volunteersRepository;
        private readonly ILogger<UpdateRequisitesCommandHandler> _logger;

        public UpdateRequisitesCommandHandler(
            IVolunteersRepository volunteersRepository,
            ILogger<UpdateRequisitesCommandHandler> logger)
        {
            _volunteersRepository = volunteersRepository;
            _logger = logger;
        }


        public async Task<Result<Guid, Error>> Handle(
            UpdateRequisitesCommand command, 
            CancellationToken cancellationToken)
        {
            var volunteerId = VolunteerId.Create(command.Id);
            var volunteerResult = await _volunteersRepository.GetById(volunteerId, cancellationToken);

            if (volunteerResult.IsFailure)
            {
                return volunteerResult.Error;
            }

            var requisitesDtos = command.Dto.Requisites;
            var requisites = requisitesDtos.Select(r => Requisite.Create(r.Title, r.Description).Value).ToList();
            
            volunteerResult.Value.UpdateRequisites(requisites);

            var guid = await _volunteersRepository.Save(volunteerResult.Value, cancellationToken);

            _logger.LogInformation("Volunteers's (id={id}) social medias list updated", guid.Value);

            return guid;
        }
    }
}

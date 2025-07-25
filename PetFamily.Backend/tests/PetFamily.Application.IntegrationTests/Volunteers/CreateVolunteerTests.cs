using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Abstractions;
using PetFamily.Application.IntegrationTests.Extensions;
using PetFamily.Application.IntegrationTests.Infrastructure;
using PetFamily.Application.Volunteers.Commands.Create;

namespace PetFamily.Application.IntegrationTests.Volunteers
{
    public class CreateVolunteerTests : BaseIntegrationTest
    {
        private readonly ICommandHandler<Guid, CreateVolunteerCommand> _sut;

        public CreateVolunteerTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
            _sut = _scope.ServiceProvider
                .GetRequiredService<ICommandHandler<Guid, CreateVolunteerCommand>>();
        }

        [Fact]
        public async Task Handle_ShouldCreateVolunteer_WhenCommandIsValid()
        {
            //Arrange
            var command = _fixture.BuildCreateVolunteerCommand();

            //Act
            var result = await _sut.Handle(command, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeEmpty();

            var volunteer = _readDbContext.Volunteers
                .FirstOrDefault(v => v.Id == result.Value);

            volunteer.Should().NotBeNull();
            volunteer.FirstName.Should().Be(command.FullName.FirstName);
        }
    }
}
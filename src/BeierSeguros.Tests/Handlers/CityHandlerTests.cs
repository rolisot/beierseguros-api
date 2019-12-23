using System.Threading;
using BeierSeguros.Domain.Cities.Commands;
using BeierSeguros.Infra.Data;
using BeierSeguros.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeierSeguros.Tests.Commands
{
    [TestClass]
    public class CityHandlerTests
    {
        private readonly AppDbContext context;

        private readonly CityRepository _repository;

        public CityHandlerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "beierSeguros")
                    .Options;

            context = new AppDbContext(options);
            _repository = new CityRepository(context);
        }

        // [TestMethod]
        // public async void ShouldReturnSuccessWhenCommandIsValid()
        // {
        //     var handler = new CreateCityCommandHandler(_repository);
        //     var command = new CreateCityCommand();

        //     command.Name = "São Paulo";
        //     command.State = "SP";

        //     var result = await handler.Handle(command, CancellationToken.None);

        //     Assert.IsTrue(result.Success);
        // }

        // [TestMethod]
        // public async void ShouldReturnErrorWhenCommandIsInvalid()
        // {
        //     var handler = new CreateCityCommandHandler(_repository);
        //     var command = new CreateCityCommand();

        //     command.Name = "São Paulo";
        //     command.State = "";

        //     var result = await handler.Handle(command, CancellationToken.None);

        //     Assert.IsFalse(result.Success);
        // }
    }
}
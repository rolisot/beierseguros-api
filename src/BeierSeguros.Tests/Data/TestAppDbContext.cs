using BeierSeguros.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BeierSeguros.Tests.Data
{
    public class TestAppDbContext : AppDbContext
    {
        public TestAppDbContext()
        {

        }

        private void Configure()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "beierSeguros")
                    .Options;
        }
    }
}
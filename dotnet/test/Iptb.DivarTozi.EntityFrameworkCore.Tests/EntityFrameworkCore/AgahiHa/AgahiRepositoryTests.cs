using System;
using System.Threading.Tasks;
using Iptb.DivarTozi.AgahiHa;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Iptb.DivarTozi.EntityFrameworkCore.AgahiHa;

public class AgahiRepositoryTests : DivarToziEntityFrameworkCoreTestBase
{
    private readonly IAgahiRepository _agahiRepository;

    public AgahiRepositoryTests()
    {
        _agahiRepository = GetRequiredService<IAgahiRepository>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
    */
}

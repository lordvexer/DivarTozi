using System;
using System.Threading.Tasks;
using Iptb.DivarTozi.MantageHa;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Iptb.DivarTozi.EntityFrameworkCore.MantageHa;

public class MantageRepositoryTests : DivarToziEntityFrameworkCoreTestBase
{
    private readonly IMantageRepository _mantageRepository;

    public MantageRepositoryTests()
    {
        _mantageRepository = GetRequiredService<IMantageRepository>();
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

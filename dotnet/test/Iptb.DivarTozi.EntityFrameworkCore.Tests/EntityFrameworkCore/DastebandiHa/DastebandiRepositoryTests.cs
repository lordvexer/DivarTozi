using System;
using System.Threading.Tasks;
using Iptb.DivarTozi.DastebandiHa;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Iptb.DivarTozi.EntityFrameworkCore.DastebandiHa;

public class DastebandiRepositoryTests : DivarToziEntityFrameworkCoreTestBase
{
    private readonly IDastebandiRepository _dastebandiRepository;

    public DastebandiRepositoryTests()
    {
        _dastebandiRepository = GetRequiredService<IDastebandiRepository>();
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

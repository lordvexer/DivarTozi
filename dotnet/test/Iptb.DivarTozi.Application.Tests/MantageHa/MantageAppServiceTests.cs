using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Iptb.DivarTozi.MantageHa;

public class MantageAppServiceTests : DivarToziApplicationTestBase
{
    private readonly IMantageAppService _mantageAppService;

    public MantageAppServiceTests()
    {
        _mantageAppService = GetRequiredService<IMantageAppService>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        // Arrange

        // Act

        // Assert
    }
    */
}


using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Iptb.DivarTozi.AgahiHa;

public class AgahiAppServiceTests : DivarToziApplicationTestBase
{
    private readonly IAgahiAppService _agahiAppService;

    public AgahiAppServiceTests()
    {
        _agahiAppService = GetRequiredService<IAgahiAppService>();
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


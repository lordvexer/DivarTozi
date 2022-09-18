using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Iptb.DivarTozi.DastebandiHa;

public class DastebandiAppServiceTests : DivarToziApplicationTestBase
{
    private readonly IDastebandiAppService _dastebandiAppService;

    public DastebandiAppServiceTests()
    {
        _dastebandiAppService = GetRequiredService<IDastebandiAppService>();
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


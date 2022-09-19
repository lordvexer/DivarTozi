using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Iptb.DivarTozi.AgahiHa;

public class AgahiAttachmentAppServiceTests : DivarToziApplicationTestBase
{
    private readonly IAgahiAttachmentAppService _agahiAttachmentAppService;

    public AgahiAttachmentAppServiceTests()
    {
        _agahiAttachmentAppService = GetRequiredService<IAgahiAttachmentAppService>();
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


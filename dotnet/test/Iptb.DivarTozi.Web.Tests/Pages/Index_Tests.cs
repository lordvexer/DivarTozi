using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Iptb.DivarTozi.Pages;

public class Index_Tests : DivarToziWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

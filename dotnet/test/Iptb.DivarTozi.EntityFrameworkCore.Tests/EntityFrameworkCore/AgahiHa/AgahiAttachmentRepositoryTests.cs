using System;
using System.Threading.Tasks;
using Iptb.DivarTozi.AgahiHa;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Iptb.DivarTozi.EntityFrameworkCore.AgahiHa;

public class AgahiAttachmentRepositoryTests : DivarToziEntityFrameworkCoreTestBase
{
    private readonly IAgahiAttachmentRepository _agahiAttachmentRepository;

    public AgahiAttachmentRepositoryTests()
    {
        _agahiAttachmentRepository = GetRequiredService<IAgahiAttachmentRepository>();
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

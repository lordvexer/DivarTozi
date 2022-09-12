using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Iptb.DivarTozi.Data;

/* This is used if database provider does't define
 * IDivarToziDbSchemaMigrator implementation.
 */
public class NullDivarToziDbSchemaMigrator : IDivarToziDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

using System.Threading.Tasks;

namespace Iptb.DivarTozi.Data;

public interface IDivarToziDbSchemaMigrator
{
    Task MigrateAsync();
}

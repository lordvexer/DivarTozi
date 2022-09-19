using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Iptb.DivarTozi.Data;
using Volo.Abp.DependencyInjection;

namespace Iptb.DivarTozi.EntityFrameworkCore;

public class EntityFrameworkCoreDivarToziDbSchemaMigrator
    : IDivarToziDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreDivarToziDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the DivarToziDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DivarToziDbContext>()
            .Database
            .MigrateAsync();
    }
}

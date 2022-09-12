using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Iptb.DivarTozi;

public class DivarToziWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<DivarToziWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}

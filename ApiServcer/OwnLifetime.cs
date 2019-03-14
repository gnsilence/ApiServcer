using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApiServcer
{
    /// <summary>
    /// //使用topshelf接管生命周期处理
    /// </summary>
    public class OwnLifetime : IHostLifetime
    {
        private IApplicationLifetime ApplicationLifetime { get; }

        public OwnLifetime(IApplicationLifetime applicationLifetime, IServiceProvider services)
        {
            ApplicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

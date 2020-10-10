using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Runners
{
    public interface ITaskRunner
    {
        Task Exec(CancellationToken stoppingToken);
    }
}

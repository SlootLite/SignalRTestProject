using BusinessLogic.Hubs;
using CoreLayer.Interfaces.Runners;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRTestProject.Workers
{
    public class LoadingWorker : BackgroundService
    {
        private readonly ITaskRunner _taskRunner;
        public LoadingWorker(ITaskRunner taskRunner)
        {
            _taskRunner = taskRunner;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                if (stoppingToken.IsCancellationRequested) break;
                await _taskRunner.Exec(stoppingToken); // вызывает выполнение задачи
            }
        }
    }
}

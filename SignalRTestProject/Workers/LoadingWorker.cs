using BusinessLogic.Hubs;
using CoreLayer.Interfaces.Runners;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CoreLayer.Interfaces.Services;

namespace SignalRTestProject.Workers
{
    public class LoadingWorker : BackgroundService
    {
        private readonly ITaskRunner _taskRunner;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public LoadingWorker(ITaskRunner taskRunner,
            IServiceScopeFactory serviceScopeFactory)
        {
            _taskRunner = taskRunner;
            _serviceScopeFactory = serviceScopeFactory;
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

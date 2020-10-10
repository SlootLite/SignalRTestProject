using BusinessLogic.Common;
using BusinessLogic.Hubs;
using CoreLayer.Exceptions;
using CoreLayer.Interfaces.Runners;
using CoreLayer.Interfaces.Services;
using CoreLayer.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Runners
{
    public class TaskRunner : ITaskRunner
    {
        private readonly ITaskService _taskService;
        private readonly PercentCalculator _percentCalculator;
        private readonly ILoadingService _loadingService;
        public TaskRunner(ITaskService taskService,
            ILoadingService loadingService)
        {
            _loadingService = loadingService;
            _taskService = taskService;
            _percentCalculator = new PercentCalculator();
        }
        public async Task Exec(CancellationToken stoppingToken)
        {
            TaskItemModel taskForExec;
            try
            {
                taskForExec = _taskService.GetNextTask();
            }
            catch (ValueNotFoundException)
            {
                return;
            }
            await Executing(taskForExec, stoppingToken);
        }
        private async Task Executing(TaskItemModel task, CancellationToken stoppingToken)
        {
            _taskService.StartTask(task.Id);
            var rand = new Random();
            var maxIndex = rand.Next(10, 30);
            var count = 0;
            while (true)
            {
                if (stoppingToken.IsCancellationRequested) break;
                count++;
                var percent = _percentCalculator.CalculatePercent(count, maxIndex);
                _taskService.UpdateTask(task.Id, percent);
                await SendLoading(task.Id); // отправим информацию о текущем состоянии задачи
                await Task.Delay(1000);
                if (count >= maxIndex)
                {
                    _taskService.CompleteTask(task.Id);
                    await SendLoading(task.Id); // отправим информацию о текущем состоянии задачи
                    break;
                }
            }
        }
        private async Task SendLoading(Guid id)
        {
            var task = _taskService.Get(id);
            await _loadingService.SendToAll(task); // отправим информацию о текущем состоянии задачи
        }
    }
}

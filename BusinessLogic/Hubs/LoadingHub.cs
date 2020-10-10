using CoreLayer.Dto;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace BusinessLogic.Hubs
{
    /// <summary>
    /// Хаб для изменения / добавления задач в обе стороны
    /// </summary>
    public class LoadingHub : Hub
    {
        private readonly ITaskService _taskService;
        private readonly ILoadingService _loadingService;
        public LoadingHub(ITaskService taskService,
            ILoadingService loadingService)
        {
            _taskService = taskService;
            _loadingService = loadingService;
        }
        /// <summary>
        /// Получит новую задачу с фронта
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Send(TaskItemCreateDto message)
        {
            var task = await _taskService.CreateTask(message);
            await _loadingService.SendToAll(task);
        }
    }
}

using BusinessLogic.Common;
using CoreLayer.Dto;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Models;
using CoreLayer.References;
using CoreLayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly INotifyService _notifyService;
        public TaskService(ITaskRepository taskRepository,
            INotifyService notifyService)
        {
            _taskRepository = taskRepository;
            _notifyService = notifyService;
        }
        public TaskItemModel GetNextTask()
        {
            return _taskRepository.GetTaskByStatus(StatusTask.WaitingToStart);
        }
        public TaskItemView Get(Guid id)
        {
            var task = _taskRepository.GetTaskById(id);
            return new TaskItemView()
            {
                Id = task.Id,
                Name = task.Name,
                PercentComplete = task.PercentComplete,
                Status = task.Status,
                StatusText = EnumDescription.GetDescription(task.Status)
            };
        }
        public IEnumerable<TaskItemView> Get()
        {
            List<TaskItemView> tasksView = new List<TaskItemView>();
            var tasks = _taskRepository.Get();
            foreach(var task in tasks)
            {
                tasksView.Add(new TaskItemView()
                {
                    Id = task.Id,
                    Name = task.Name,
                    PercentComplete = task.PercentComplete,
                    Status = task.Status,
                    StatusText = EnumDescription.GetDescription(task.Status)
                });
            }
            return tasksView;
        }
        public async Task<TaskItemView> CreateTask(TaskItemCreateDto taskItem)
        {
            var taskId = _taskRepository.Add(new TaskItemModel() 
            {
                Name = taskItem.TaskName.Trim(),
                PercentComplete = 0,
                Status = StatusTask.WaitingToStart
            });
            var task = _taskRepository.GetTaskById(taskId);
            await _notifyService.SendToClient(taskItem.NotifyConnectionId, $"Вы поставили задачу '{taskItem.TaskName.Trim()}' в очередь");
            await _notifyService.SendExceptClient(taskItem.NotifyConnectionId, $"Добавлена новая задача '{taskItem.TaskName.Trim()}'");
            return new TaskItemView()
            {
                Id = task.Id,
                Name = task.Name,
                PercentComplete = task.PercentComplete,
                Status = task.Status,
                StatusText = EnumDescription.GetDescription(task.Status)
            };
        }
        public void StartTask(Guid id)
        {
            var task = _taskRepository.GetTaskById(id);
            task.PercentComplete = 0;
            task.Status = StatusTask.InProgress;
            _taskRepository.Update(task);
        }
        public void UpdateTask(Guid id, int percent)
        {
            var task = _taskRepository.GetTaskById(id);
            task.PercentComplete = percent;
            task.Status = StatusTask.InProgress;
            _taskRepository.Update(task);
        }
        public void CompleteTask(Guid id)
        {
            var task = _taskRepository.GetTaskById(id);
            task.PercentComplete = 100;
            task.Status = StatusTask.Complete;
            _taskRepository.Update(task);
        }
    }
}

using CoreLayer.Dto;
using CoreLayer.Models;
using CoreLayer.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface ITaskService
    {
        TaskItemModel GetNextTask();
        void CompleteTask(Guid id);
        void StartTask(Guid id);
        void UpdateTask(Guid id, int percent);
        Task<TaskItemView> CreateTask(TaskItemCreateDto taskItem);
        IEnumerable<TaskItemView> Get();
        TaskItemView Get(Guid id);
    }
}

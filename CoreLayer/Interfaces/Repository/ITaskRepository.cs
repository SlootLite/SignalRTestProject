using CoreLayer.Models;
using CoreLayer.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Interfaces.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItemModel> Get();
        TaskItemModel GetTaskById(Guid id);
        TaskItemModel GetTaskByStatus(StatusTask status);
        Guid Add(TaskItemModel task);
        void Update(TaskItemModel item);
        void Delete(Guid id);
    }
}

using CoreLayer.Exceptions;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Models;
using CoreLayer.References;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<TaskItemModel> _tasks = new List<TaskItemModel>()
        {
            new TaskItemModel()
            {
                Id = Guid.NewGuid(),
                Name = "Первая тестовая задача",
                PercentComplete = 0,
                Status = StatusTask.WaitingToStart
            },
            new TaskItemModel()
            {
                Id = Guid.NewGuid(),
                Name = "Вторая тестовая задача",
                PercentComplete = 0,
                Status = StatusTask.WaitingToStart
            },
        };
        public IEnumerable<TaskItemModel> Get()
        {
            return _tasks;
        }
        public TaskItemModel GetTaskById(Guid id)
        {
            foreach(var task in _tasks)
            {
                if (task.Id.Equals(id))
                    return task;
            }
            throw new ValueNotFoundException("Указанная задача не найдена");
        }
        public TaskItemModel GetTaskByStatus(StatusTask status)
        {
            foreach (var task in _tasks)
            {
                if (task.Status.Equals(status))
                    return task;
            }
            throw new ValueNotFoundException("Указанная задача не найдена");
        }
        public Guid Add(TaskItemModel task)
        {
            task.Id = Guid.NewGuid();
            task.PercentComplete = 0;
            task.Status = StatusTask.WaitingToStart;
            task.Name = task.Name.Trim();
            _tasks.Add(task);
            return task.Id;
        }
        public void Update(TaskItemModel item)
        {
            foreach(var task in _tasks)
            {
                if (task.Id.Equals(item.Id))
                {
                    task.Name = item.Name;
                    task.PercentComplete = item.PercentComplete;
                    task.Status = item.Status;
                    return;
                }
            }
            throw new ValueNotFoundException("Указанная задача не найдена");
        }
        public void Delete(Guid id)
        {
            foreach (var task in _tasks)
            {
                if (task.Id.Equals(id))
                {
                    _tasks.Remove(task);
                    return;
                }
            }
            throw new ValueNotFoundException("Указанная задача не найдена");
        }
    }
}

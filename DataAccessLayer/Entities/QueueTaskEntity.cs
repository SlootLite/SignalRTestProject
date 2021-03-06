using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    /// <summary>Элемент очереди задач</summary>
    public class QueueTaskEntity
    {
        /// <summary>Id задачи</summary>
        public Guid Id { get; set; }
        /// <summary>Процент выполнения задачи</summary>
        public int PercentComplete { get; set; }
        /// <summary>Наименование задачи</summary>
        public string Name { get; set; }
        /// <summary>Дата создания</summary>
        public DateTime CreateDate { get; set; }
        /// <summary>Дата завершения</summary>
        public DateTime? CompleteDate { get; set; }
        /// <summary>Статус задачи</summary>
        public int QueueTaskStatusId { get; set; }
        /// <summary>Статус задачи</summary>
        public QueueTaskStatusEntity QueueTaskStatus { get; set; }
    }
}

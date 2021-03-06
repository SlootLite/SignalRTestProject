using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    /// <summary>Статус выполнения задачи</summary>
    public class QueueTaskStatusEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

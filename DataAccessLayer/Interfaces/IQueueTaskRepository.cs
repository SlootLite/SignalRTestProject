using CoreLayer.Interfaces.Repository;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IQueueTaskRepository : IRepository<QueueTaskEntity>, IChildRelations
    {
    }
}

using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class QueueTaskStatusRepository : Repository<QueueTaskStatusEntity>, IQueueTaskStatusRepository
    {
        public QueueTaskStatusRepository(ApplicationContext context) : base(context, context.QueueTaskStatuses)
        {
        }
    }
}

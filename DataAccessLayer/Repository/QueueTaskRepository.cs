using CoreLayer.Interfaces.Repository;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repository
{
    public class QueueTaskRepository : Repository<QueueTaskEntity>, IQueueTaskRepository
    {
        public QueueTaskRepository(ApplicationContext context) : base(context, context.QueueTasks)
        {
        }

        public void IncludeChildRelations()
        {
            this.SetQuery(_context.QueueTasks.Include(s => s.QueueTaskStatus));
        }

        public void ClearChildRelations()
        {
            this.ClearQuery();
        }
    }
}

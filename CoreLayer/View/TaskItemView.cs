using CoreLayer.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.View
{
    public class TaskItemView
    {
        /// <summary>
        /// Id задачи
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Статус задачи
        /// </summary>
        public StatusTask Status { get; set; }
        /// <summary>
        /// Статус задачи (текст)
        /// </summary>
        public string StatusText { get; set; }
        /// <summary>
        /// Процент выполнения задачи
        /// </summary>
        public int PercentComplete { get; set; }
        /// <summary>
        /// Наименование задачи
        /// </summary>
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoreLayer.References
{
    /// <summary>
    /// Статусы задач
    /// </summary>
    public enum StatusTask
    {
        /// <summary>
        /// Создана. Ожидает начала работы
        /// </summary>
        [Description("В ожидании")]
        WaitingToStart = 1,
        /// <summary>
        /// Выполняется
        /// </summary>
        [Description("В работе")]
        InProgress = 2,
        /// <summary>
        /// Завершена
        /// </summary>
        [Description("Завершена")]
        Complete = 3,
        /// <summary>
        /// Пауза
        /// </summary>
        [Description("Пауза")]
        Pause = 4,
        /// <summary>
        /// Ошибка
        /// </summary>
        [Description("Ошибка")]
        Error = 5
    }
}

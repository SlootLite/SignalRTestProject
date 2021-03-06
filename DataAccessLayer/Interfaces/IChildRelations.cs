using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    /// <summary>Управление связью с родственными сущностями</summary>
    public interface IChildRelations
    {
        /// <summary>Включить в результат запросов родственные сущности</summary>
        void IncludeChildRelations();
        /// <summary>Очистить резулььтат запроса от родственных сущностей</summary>
        void ClearChildRelations();
    }
}

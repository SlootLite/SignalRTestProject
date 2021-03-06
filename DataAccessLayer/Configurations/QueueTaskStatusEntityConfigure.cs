using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Configurations
{
    public class QueueTaskStatusEntityConfigure : IEntityTypeConfiguration<QueueTaskStatusEntity>
    {
        public void Configure(EntityTypeBuilder<QueueTaskStatusEntity> builder)
        {
            builder.ToTable("QueueTaskStatuses");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .HasColumnType("nvarchar(30)")
                .IsRequired();
            builder.Property(v => v.Description)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.HasData(
               new { Id = 1, Name = "WaitingToStart", Description = "Создана. Ожидает начала работы" },
               new { Id = 2, Name = "InProgress", Description = "Выполняется" },
               new { Id = 3, Name = "Complete", Description = "Завершена" },
               new { Id = 4, Name = "Pause", Description = "Пауза" },
               new { Id = 5, Name = "Error", Description = "Ошибка" }
               );
        }
    }
}

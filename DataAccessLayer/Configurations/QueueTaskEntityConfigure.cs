using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Configurations
{
    public class QueueTaskEntityConfigure : IEntityTypeConfiguration<QueueTaskEntity>
    {
        public void Configure(EntityTypeBuilder<QueueTaskEntity> builder)
        {
            builder.ToTable("QueueTasks");

            builder.HasKey(d => d.Id);

            builder.Property(s => s.PercentComplete)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();
            builder.Property(d => d.Name)
                .HasColumnType("nvarchar(300)")
                .IsRequired(false);
            builder.Property(d => d.CreateDate)
                .HasColumnType("DateTime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
            builder.Property(d => d.CompleteDate)
                .HasColumnType("DateTime")
                .IsRequired(false);
            builder.Property(d => d.QueueTaskStatusId)
                .IsRequired();

            builder.HasOne(v => v.QueueTaskStatus)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreLayer.Dto
{
    public class TaskItemCreateDto
    {
        [Required]
        [StringLength(100)]
        public string TaskName { get; set; }
        public string NotifyConnectionId { get; set; }
    }
}

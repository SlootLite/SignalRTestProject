using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface INotifyService
    {
        Task SendToClient(string connectionId, object message);
        Task SendExceptClient(string connectionId, object message);
    }
}

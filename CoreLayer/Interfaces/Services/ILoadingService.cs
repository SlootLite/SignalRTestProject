using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface ILoadingService
    {
        Task SendToAll(object message);
    }
}

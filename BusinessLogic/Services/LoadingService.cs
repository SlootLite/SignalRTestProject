using BusinessLogic.Hubs;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Сервис, который отправляет сообщения на фронт (данные о добавленной / измененной задаче)
    /// </summary>
    public class LoadingService : ILoadingService
    {
        private readonly IHubContext<LoadingHub> _loadingContext;
        private const string _method = "Send";
        public LoadingService(IHubContext<LoadingHub> loadingContext)
        {
            _loadingContext = loadingContext;
        }
        /// <summary>
        /// Отправить всем сообщение
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendToAll(object message)
        {
            await _loadingContext.Clients.All.SendAsync(_method, message);
        }
    }
}

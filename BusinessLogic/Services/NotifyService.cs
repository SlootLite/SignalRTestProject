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
    /// Сервис, который отправляет сообщения на фронт ( уведомления )
    /// </summary>
    public class NotifyService : INotifyService
    {
        private readonly IHubContext<NotifyHub> _notifyContext;
        private const string _method = "Notify";
        public NotifyService(IHubContext<NotifyHub> notifyContext)
        {
            _notifyContext = notifyContext;
        }
        /// <summary>
        /// Отправить сообщение конкретному пользователю
        /// </summary>
        /// <param name="connectionId">Id подключения</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendToClient(string connectionId, object message)
        {
            await _notifyContext.Clients.Client(connectionId).SendAsync(_method, message);
        }
        /// <summary>
        /// Отправить сообщение всем, кроме конкретного пользователя
        /// </summary>
        /// <param name="connectionId">Id подключения</param>
        /// <param name="message">Отправленное сообщение</param>
        /// <returns></returns>
        public async Task SendExceptClient(string connectionId, object message)
        {
            await _notifyContext.Clients.AllExcept(connectionId).SendAsync(_method, message);
        }
    }
}

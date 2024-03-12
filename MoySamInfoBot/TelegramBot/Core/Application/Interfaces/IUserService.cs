using MoySamInfoBot.TelegramBot.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Core.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByChatIdAsync(long  chatId);
    }
}

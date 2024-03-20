using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Core.Application.Interfaces
{
    public interface IUserService
    {
        Task<IUser> GetUserByIdAsync(long  chatId);
        Task Save(IUser user);
    }
}

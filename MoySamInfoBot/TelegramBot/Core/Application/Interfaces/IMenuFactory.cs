using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace MoySamInfoBot.TelegramBot.Core.Application.Interfaces
{
    public interface IMenuFactory
    {
        IMenu GetMenu(IUser user, ITelegramBotClient botClient);
    }
}

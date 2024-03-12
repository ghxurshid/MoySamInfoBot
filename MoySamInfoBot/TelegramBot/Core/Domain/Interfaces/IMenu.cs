using MoySamInfoBot.TelegramBot.Core.Domain.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Interfaces
{
    public interface IMenu
    {        
        Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken);
    }
}

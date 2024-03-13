using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace MoySamInfoBot.TelegramBot.Core.Application.UpdateHandlers
{
    public interface IUpdateHandler
    {
        Task Handle(ITelegramBotClient client, Update update, CancellationToken cancellationToken);
    }
}

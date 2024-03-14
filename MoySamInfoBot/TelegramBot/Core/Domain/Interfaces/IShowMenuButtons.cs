using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Interfaces
{
    public interface IShowMenuButtons
    {
        Task ShowMenu(long chatId, ITelegramBotClient client, CancellationToken cancellationToken);
    }
}

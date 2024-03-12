using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Delegates
{
    delegate Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken cancellationToken);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MoySamInfoBot.TelegramBot.Core.Application.UpdateHandlers
{
    public class BaseHandler
    {
        public async Task Handle(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

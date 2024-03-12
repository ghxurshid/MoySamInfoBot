using MoySamInfoBot.TelegramBot.Core.Domain.Delegates;
using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Menus
{
    public class BaseMenu : IMenu
    {
        protected int value;
        protected readonly Dictionary<UpdateType, UpdateHandler> handlers = new();

        public IMenu Prev { get; set; } = default!;
        public IEnumerable<IMenu> Menus { get; set; } = default!;

        public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            var type = update.Type;

            if (handlers.ContainsKey(type))
            {
                var handler = handlers[type];
                await handler.Invoke(client, update, cancellationToken);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}

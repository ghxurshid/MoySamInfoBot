using MoySamInfoBot.TelegramBot.Core.Domain.Delegates;
using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
 

namespace MoySamInfoBot.TelegramBot.Core.Domain.Menus
{
    public class BaseMenu : IMenu
    {
        protected readonly Dictionary<UpdateType, UpdateHandler> updateHandlers = new();
        protected readonly Dictionary<MessageType, MessageHandler> messageHandlers = new();

        public IMenu Prev { get; set; } = default!;
        public  IEnumerable<IMenu> Menus { get; set; } = default!;

        public BaseMenu()
        {
            updateHandlers[UpdateType.Message] = DefaultHandleMessageAsync;
        }        

        public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            var type = update.Type;

            if (updateHandlers.ContainsKey(type))
            {
                var handler = updateHandlers[type];
                await handler.Invoke(client, update, cancellationToken);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task DefaultHandleMessageAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
                return;

            var type = message.Type;

            if (messageHandlers.ContainsKey(type))
            {
                var handler = messageHandlers[type];
                await handler.Invoke(client, message, cancellationToken);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}

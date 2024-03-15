using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain.Delegates;
using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


namespace MoySamInfoBot.TelegramBot.Core.Domain.Menus
{
    public abstract class BaseMenu : IMenu
    {
        protected readonly IResourceManager _resourceManager;

        protected readonly Dictionary<UpdateType, UpdateHandler> updateHandlers = new();
        protected readonly Dictionary<MessageType, MessageHandler> messageHandlers = new();

        private IMenu _prev { get; set; } = default!;
        private IDictionary<MenuNumber, IMenu> _menus { get; set; } = default!;

        public BaseMenu(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
            updateHandlers[UpdateType.Message] = DefaultHandleMessageAsync;

            _menus = new Dictionary<MenuNumber, IMenu>();
        }

        public async Task HandleUpdateAsync(User user, ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            var type = update.Type;

            if (updateHandlers.ContainsKey(type))
            {
                var handler = updateHandlers[type];
                await handler.Invoke(user, client, update, cancellationToken);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task DefaultHandleMessageAsync(User user, ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
                return;

            var type = message.Type;

            if (messageHandlers.ContainsKey(type))
            {
                var handler = messageHandlers[type];
                await handler.Invoke(user, client, message, cancellationToken);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task ShowMenu(long userId, ITelegramBotClient client, CancellationToken cancellationToken)
        {
            var sentMessage = await client.SendTextMessageAsync(
                chatId: userId,
                text: Message(),
                replyMarkup: Keyboard(),
                cancellationToken: cancellationToken);
        }

        protected abstract IReplyMarkup Keyboard();
        protected abstract string Message();
    }
}

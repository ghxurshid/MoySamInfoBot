using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain.Menus;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using Message = Telegram.Bot.Types.Message;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Pages
{
    public class StartMenu : BaseMenu
    {
        public StartMenu() : base()
        {
            //updateHandlers[UpdateType.Message] = MessageHandleAsync;
            messageHandlers[MessageType.Text] = TextHandleAsync; 
        }
        public async Task MessageHandleAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
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

        public async Task TextHandleAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] { "Help me2", "Call me ☎️" },
            })
            {
                ResizeKeyboard = true
            };

            var sentMessage = await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "You said:\n" + message.Text,
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);
        }
    }
}

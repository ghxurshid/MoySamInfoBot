using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Pages
{
    public class StartMenu : BaseMenu
    {
        public StartMenu()
        {
            handlers[UpdateType.Message] = MessageHandleAsync;
        }
        public async Task MessageHandleAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] { "Help me", "Call me ☎️" },
            })
            {
                ResizeKeyboard = true
            };

            var sentMessage = await client.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "You said:\n" + update.Message.Text,
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);
        }
    }
}

using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain.Menus;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using Message = Telegram.Bot.Types.Message;
using Microsoft.VisualBasic;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Pages
{
    public class StartMenu : BaseMenu, IShowMenuButtons
    {
        public StartMenu() : base()
        {            
            messageHandlers[MessageType.Text] = TextHandleAsync; 
        } 

        public async Task ShowMenu(long chatId, ITelegramBotClient client, CancellationToken cancellationToken)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] { "Help me", "Call me ☎️" },
            })
            {
                ResizeKeyboard = true
            };

            Message sentMessage = await client.SendTextMessageAsync(
                chatId: chatId,
                text: "Boshlash uchun \"Start\" ni bosing",
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
        }

        public async Task TextHandleAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            if (message.Text is not { } text)
                return;

            if (text.Equals("/start"))
            {

            }
            var sentMessage = await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "You said:\n" + message.Text, 
                cancellationToken: cancellationToken);
        }
    }
}

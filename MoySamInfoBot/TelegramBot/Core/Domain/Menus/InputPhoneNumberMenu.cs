using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;
using Telegram.Bot.Types;
using Message = Telegram.Bot.Types.Message;
using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using System.Windows.Forms;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Menus
{
    public class InputPhoneNumberMenu : BaseMenu, IShowMenuButtons
    {
        public InputPhoneNumberMenu() : base()
        {
            messageHandlers[MessageType.Text] = TextHandleAsync;
        }

        public async Task ShowMenu(long chatId, ITelegramBotClient client, CancellationToken cancellationToken)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            { 
                KeyboardButton.WithRequestContact("Ulashish ☎️"),
            });

            var sentMessage = await client.SendTextMessageAsync(
                chatId: chatId,
                text: "Telefon raqamingizni yuboring:\n",
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);
        }

        public async Task TextHandleAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
             
        }
    }
}

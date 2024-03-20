using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Message = Telegram.Bot.Types.Message;

namespace MoySamInfoBot.TelegramBot.Core.Application.Menus
{
    public class InputPhoneMenu : BaseMenu, IMenu
    {
        public InputPhoneMenu(IUser user, ITelegramBotClient client) : base(user, client)
        {

        }

        public Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async void Show(CancellationToken cancellationToken)
        {
            if (_client != null)
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                { 
                    new KeyboardButton[] { "Ulashish ☎️" }
                })
                {
                    ResizeKeyboard = true
                };

                Message sentMessage = await _client.SendTextMessageAsync(
                    chatId: _user.UserId,
                    text: "Telefon raqamingizni kiriting ☎️",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
            }
        }
    }
}

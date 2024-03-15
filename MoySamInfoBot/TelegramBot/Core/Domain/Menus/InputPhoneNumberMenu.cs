using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Message = Telegram.Bot.Types.Message;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Menus
{
    public class InputPhoneNumberMenu : BaseMenu, IShowMenuButtons
    {
        public InputPhoneNumberMenu(IResourceManager resourceManager) : base(resourceManager)
        {
            messageHandlers[MessageType.Text] = TextHandleAsync;
        }

        public async Task TextHandleAsync(User user, ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {

        }

        protected override IReplyMarkup Keyboard()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            { 
                KeyboardButton.WithRequestContact("Ulashish ☎️"),
            });

            return replyKeyboardMarkup;
        }

        protected override string Message()
        {
            return "Telefon raqamingizni yuboring:\n";
        }
    }
}

using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain.Menus;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using Message = Telegram.Bot.Types.Message;
using Microsoft.VisualBasic;
using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Application.Constants;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Pages
{
    public class StartMenu : BaseMenu, IShowMenuButtons
    {
        public StartMenu(IResourceManager resourceManager) : base(resourceManager)
        {            
            messageHandlers[MessageType.Text] = TextHandleAsync; 
        } 
         
        public async Task TextHandleAsync(User user, ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            if (message.Text is not { } text)
                return;

            var commandName = _resourceManager.CommandNameByKey(CommandConst.Start, user.LanguageCode);

            if (text.Equals(commandName))
            {
                if (Menus.TryGetValue(Enums.MenuNumber.InputPhoneNumber, out var phoneNumberMenu))
                {
                    await phoneNumberMenu.ShowMenu(user.UserId, client, cancellationToken);
                }                 
            }            
        }

        protected override IReplyMarkup Keyboard()
        {
            return new ReplyKeyboardRemove();
        }

        protected override string Message()
        {
            return "Boshlash uchun \"Start\" ni bosing";
        }
    }
}

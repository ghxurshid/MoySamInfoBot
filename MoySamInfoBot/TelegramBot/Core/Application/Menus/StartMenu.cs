using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using Message = Telegram.Bot.Types.Message;
using Microsoft.VisualBasic;
using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Application.Constants;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using MoySamInfoBot.TelegramBot.Core.Domain.Enums;

namespace MoySamInfoBot.TelegramBot.Core.Application.Menus
{
    public class StartMenu : BaseMenu, IMenu
    {
        public StartMenu(IUser user, ITelegramBotClient client) : base(user, client)
        {
            
        }

        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
                return;
            if (message.Text is not { } text)
                return;

            var commandName = _resourceManager.CommandNameByKey(CommandConst.Start, _user.LanguageCode);

            if (commandName.Equals(CommandConst.Start))
            {
                _user.MenuNumber = MenuNumber.InputPhoneNumber;
                await _userService.Save(_user);
                var menu = _menuFactory.GetMenu(_user, _client);
                menu.Show(cancellationToken);
            }
        }

        public async void Show(CancellationToken cancellationToken)
        {
            
        }
    }
}

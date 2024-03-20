using Autofac;
using MoySamInfoBot.TelegramBot.Core.Application;
using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Interfaces
{
    public class BaseMenu
    {        
        protected readonly IUser _user;
        protected ITelegramBotClient _client;
        protected readonly IMenuFactory _menuFactory;
        protected readonly IUserService _userService;
        protected readonly IResourcesManager _resourceManager;        

        public BaseMenu(IUser userModel, 
            ITelegramBotClient client)
        {
            _user = userModel;
            _client = client;
            _menuFactory = DependencyInjection.Container.Resolve<IMenuFactory>();
            _userService = DependencyInjection.Container.Resolve<IUserService>();
            _resourceManager = DependencyInjection.Container.Resolve<IResourcesManager>();            
        } 
    }
}

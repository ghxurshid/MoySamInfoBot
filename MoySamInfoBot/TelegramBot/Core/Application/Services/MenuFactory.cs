using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Application.Menus;
using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using IUser = MoySamInfoBot.TelegramBot.Core.Domain.Interfaces.IUser;

namespace MoySamInfoBot.TelegramBot.Core.Application.Services
{
    public class MenuFactory : IMenuFactory
    {  
        public IMenu GetMenu(IUser user, ITelegramBotClient client)
        { 
            return new StartMenu(user, client);          
        }
    }
}

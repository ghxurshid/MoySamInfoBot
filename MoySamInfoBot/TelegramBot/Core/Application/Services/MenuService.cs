using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain;
using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain.Menus;
using MoySamInfoBot.TelegramBot.Core.Domain.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Core.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IDictionary<MenuNumber, IMenu> _menus;

        public MenuService()
        {
            var rm = new ResourceManagerService();

            var startMenu = new StartMenu(rm);
            var inputPhone = new InputPhoneNumberMenu(rm)
            {
                _prev = startMenu
            };
            startMenu._menus[MenuNumber.InputPhoneNumber] = inputPhone;

            _menus = new Dictionary<MenuNumber, IMenu>
            {
                [MenuNumber.StartMenu] = startMenu,
                [MenuNumber.InputPhoneNumber] = inputPhone
            };
        }

        public IMenu GetMenuByUser(User user)
        {
            var menu = _menus[user.MenuNumber];
            return menu;          
        }
    }
}

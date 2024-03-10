using MoySamInfoBot.TelegramBot.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Presentation
{
    public class BotController
    {        
        private readonly UserService _userService;      
        private readonly StateService _stateService;

        public BotController(UserService userService, StateService stateService)
        {
            _userService = userService;
            _stateService = stateService;
        }

        public async Task HandleMessageAsync(Message message)
        {
            // Получить пользователя
            var user = _userService.GetUser(message.Chat.Id);

            // Получить состояние пользователя
            var userState = _stateService.GetUserState(user);

            // Обработка сообщения в зависимости от состояния пользователя
            switch (userState)
            {
                case UserState.MainMenu:
                    await HandleMainMenu(message, user);
                    break;
                case UserState.SubMenu:
                    await HandleSubMenu(message, user);
                    break;
                    // Другие возможные состояния
            }
        }

        private async Task HandleMainMenu(Message message, User user)
        {
            // Обработка главного меню
            var menu = _menuService.GetMainMenu();
            var response = _telegramBot.BuildMenuResponse(menu);
            await _telegramBot.SendMessageAsync(message.Chat.Id, response);
        }

        private async Task HandleSubMenu(Message message, User user)
        {
            // Обработка подменю
            var menu = _menuService.GetSubMenu();
            var response = _telegramBot.BuildMenuResponse(menu);
            await _telegramBot.SendMessageAsync(message.Chat.Id, response);
        }
    }
}

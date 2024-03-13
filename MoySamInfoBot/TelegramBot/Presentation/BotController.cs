using MoySamInfoBot.TelegramBot.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MoySamInfoBot.TelegramBot.Presentation
{
    public class BotController
    {        
        private readonly UserService _userService;
        private readonly MenuService _menuService;

        private TelegramBotClient _client;
        private CancellationTokenSource _cts;

        public BotController(UserService userService, MenuService menuService)
        {
            _userService = userService;
            _menuService = menuService;

            _cts = new();
            _client = new TelegramBotClient("767554006:AAFCcBzxxdnsgHJVMb3Rn96pHlTC9a-APwk"); 
        }

        public void Start()
        {
            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            _client.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: _cts.Token
            );
        }

        public void Stop()
        {
            _cts.Cancel();
        }

        ~BotController()
        {
            Stop();
        }

        async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {             
            if (update.Message is not { } message)
                return;
            
            

            var chatId = message.Chat.Id;

            var user = await _userService.GetUserByChatIdAsync(chatId);
            var menu = _menuService.GetMenuByNumber(user.MenuNumber);

            await menu.HandleUpdateAsync(client, update, cancellationToken);            
        }

        Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}

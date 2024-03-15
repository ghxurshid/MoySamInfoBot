using MoySamInfoBot.TelegramBot.Core.Application.Services;
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

        public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            try
            {
                var handler = update switch
                {
                    { Message: { } } => HandleMessageUpdate(client, update, cancellationToken),
                    { EditedMessage: { } } => HandleMessageUpdate(client, update, cancellationToken),
                    { CallbackQuery: { } } => HandleCallbackQueryUpdate(client, update, cancellationToken),
                    _ => UnknownUpdateHandlerAsync(client, update, cancellationToken)
                };
            }
            catch (Exception exception)
            {
                HandleErrorAsync(exception, cancellationToken);
            }
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

        private void HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            _cts.Cancel();
        }

        private async Task HandleMessageUpdate(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
                return;

            var userId = message.From?.Id ?? 0;

            await HandleUpdateByUserId(userId, client, update, cancellationToken);
        }

        private async Task HandleCallbackQueryUpdate(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            if (update.CallbackQuery is not { } callbackQuery)
                return;

            var userId = callbackQuery.From.Id;

            await HandleUpdateByUserId(userId, client, update, cancellationToken);
        }

        private async Task UnknownUpdateHandlerAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private async Task HandleUpdateByUserId(long userId, ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            var menu = _menuService.GetMenuByUser(user);

            await menu.HandleUpdateAsync(user, client, update, cancellationToken);
        }
    }
}

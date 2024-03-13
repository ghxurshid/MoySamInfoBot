using Telegram.Bot.Types;
using Telegram.Bot;
using Message = Telegram.Bot.Types.Message;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Delegates
{
    public delegate Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken cancellationToken);
    public delegate Task MessageHandler(ITelegramBotClient client, Message update, CancellationToken cancellationToken);
}

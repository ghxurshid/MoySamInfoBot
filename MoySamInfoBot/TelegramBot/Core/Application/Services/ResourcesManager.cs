using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Application.Resources;
using System.Collections;
using System.Globalization;
using System.Resources;

namespace MoySamInfoBot.TelegramBot.Core.Application.Services
{
    public class ResourcesManager : IResourcesManager
    {
        private readonly ResourceManager _commands;
        private readonly ResourceManager _messages;

        public ResourcesManager()
        {
            _commands = new ResourceManager("CardXabar.Application.Resources.Commands",
                typeof(ResouceManagerScanner).Assembly);

            _messages = new ResourceManager("CardXabar.Application.Resources.Messages",
                typeof(ResouceManagerScanner).Assembly);
        }

        public string CommandKeyByName(string name, string languageCode)
        {
            // Получаем ресурсы для указанной культуры
            var resourceSet = _commands.GetResourceSet(new CultureInfo(languageCode), true, true);

            if (resourceSet != null)
            {
                // Ищем ключ по значению
                foreach (DictionaryEntry entry in resourceSet)
                {
                    if (entry.Value?.ToString()?.Equals(name, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return entry.Key?.ToString() ?? string.Empty;
                    }
                }
            }

            return string.Empty;
        }

        public string CommandNameByKey(string key, string languageCode)
        {
            // Получаем ресурсы для указанной культуры
            var resourceSet = _commands.GetResourceSet(new CultureInfo(languageCode), true, true);

            // Возвращаем значение по ключу
            return resourceSet?.GetString(key) ?? string.Empty;
        }

        public string MessageTextByKey(string key, string languageCode)
        {
            // Получаем ресурсы для указанной культуры
            var resourceSet = _messages.GetResourceSet(new CultureInfo(languageCode), true, true);

            // Возвращаем значение по ключу
            return resourceSet?.GetString(key) ?? string.Empty;
        }
    }
}

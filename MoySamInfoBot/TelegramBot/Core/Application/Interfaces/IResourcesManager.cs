using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Core.Application.Interfaces
{
    public interface IResourcesManager
    {
        string CommandNameByKey(string key, string languageCode);
        string CommandKeyByName(string name, string languageCode);
        string MessageTextByKey(string key, string languageCode);
    }
}

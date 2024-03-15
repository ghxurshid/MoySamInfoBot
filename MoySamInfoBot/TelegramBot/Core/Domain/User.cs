using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Core.Domain
{
    public class User
    {
        public long UserId { get; set; }

        public MenuNumber MenuNumber { get; set; }
        public string LanguageCode { get; set; } = string.Empty;
    }
}

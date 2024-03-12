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
        public int ChatId { get; set; }

        public MenuNumber MenuNumber { get; set; }
    }
}

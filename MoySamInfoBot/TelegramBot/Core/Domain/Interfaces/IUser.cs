using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Core.Domain.Interfaces
{
    public interface IUser
    {
        long UserId { get; set; }

        MenuNumber MenuNumber { get; set; }
        string LanguageCode { get; set; }
    }
}

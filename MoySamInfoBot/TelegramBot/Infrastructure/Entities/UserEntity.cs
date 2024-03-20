using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Infrastructure.Entities
{
    public class UserEntity : IUser
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public MenuNumber MenuNumber { get; set; }
    }
}

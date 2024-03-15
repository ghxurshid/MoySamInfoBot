using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain;
using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Core.Application.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserByIdAsync(long userId)
        {
            return new User
            {
                UserId = userId,
                MenuNumber = MenuNumber.StartMenu
            };
        }
    }
}

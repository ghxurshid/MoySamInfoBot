using Autofac;
using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using MoySamInfoBot.TelegramBot.Core.Domain.Interfaces;
using MoySamInfoBot.TelegramBot.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Core.Application.Services
{
    public class UserService : IUserService
    {
        protected readonly Context _context;

        public UserService()
        {
            _context = DependencyInjection.Container.Resolve<Context>();
        }
        public async Task<IUser> GetUserByIdAsync(long userId)
        {
            var user = _context?.Users.Where(u => u.UserId == userId).FirstOrDefault();
              
            return await Task.FromResult(user);             
        }

        public async Task Save(IUser user)
        {
            var user2 = _context?.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();

            if (user2 != null)
            {
                user2.MenuNumber = user.MenuNumber;
            }             
        }
    }
}

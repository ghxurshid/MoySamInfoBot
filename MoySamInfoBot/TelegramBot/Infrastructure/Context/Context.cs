using MoySamInfoBot.TelegramBot.Core.Domain.Enums;
using MoySamInfoBot.TelegramBot.Infrastructure.Entities;
using System.Data;

namespace MoySamInfoBot.TelegramBot.Infrastructure.Context
{
    public partial class Context : LinkConverter
    {
        public Context() 
        {
            Users = new List<UserEntity>
            {
                new ()
                {
                    Id = 222512490,
                    UserName = "khurshid",
                    MenuNumber = MenuNumber.StartMenu
                }
            };
        }
    }
}

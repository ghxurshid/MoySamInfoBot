using MoySamInfoBot.TelegramBot.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoySamInfoBot.TelegramBot.Infrastructure.Context
{
    public partial class Context
    {
        public List<UserEntity> Users {  get; set; }
    }
}

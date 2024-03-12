using MoySamInfoBot.TelegramBot.Core.Application.Services;
using MoySamInfoBot.TelegramBot.Presentation;
 

namespace MoySamInfoBot
{
    public partial class Form1 : Form
    {
        private readonly BotController _bot;
        public Form1()
        {
            InitializeComponent();

            _bot = new BotController(new UserService(), new MenuService()
                );
            _bot.Start();
        } 
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Tg_test
{
    public class TgHostedService : BackgroundService
    {
        private static ITelegramBotClient _tClient { get; set; }
        // private static long adminUid = GIT_IGNORE.adminUid;
        private static long adminUid = 719542068; // EDIT!!!!
        private static string token = "1328828756:AAFcrvtfg0uazEKIpMw3TPJUWfKLWMQCCvU"; // EDIT!!!!


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _tClient = new TelegramBotClient(token)
                {
                    Timeout = TimeSpan.FromSeconds(10)
                };

                var me = _tClient.GetMeAsync().Result;
            
                Console.WriteLine(
                    $"Hello World! My name is {me.FirstName}, id = {me.Id}");

                _tClient.OnMessage += (sender, e) =>
                {
                    var text = e?.Message?.Text;
                    var uid = e?.Message?.Chat?.Id;
                    var userName = e?.Message?.From?.Username;
                    
                    if (text is null)
                        return;

                    Console.WriteLine($"{uid} : {text}");
                    
                    switch (text)
                    {
                        case "/start":
                            var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                    new[]
                                    {
                                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("/help"),
                                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("/admin"),
                                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("/today"),
                                    },
                                },
                                ResizeKeyboard = true
                            };
                            _tClient.SendTextMessageAsync(uid, $"Hello world!\nMy commands:\n /today\n /start\n  /help\n /admin", replyMarkup: keyboard);
                            break;
                        case "/today":
                            _tClient.SendTextMessageAsync(uid, $"Now : {DateTime.Now.ToString("f")}");
                            break;
                        case "/help":
                            _tClient.SendTextMessageAsync(uid, "Not implemented yet. :)");
                            break;
                        case "/admin":
                            _tClient.SendTextMessageAsync(uid, "Admin has recived your conseravtion!");
                            _tClient.SendTextMessageAsync(adminUid, $"@{userName} is calling help!");
                            break;
                        default:
                            _tClient.SendTextMessageAsync(uid, $"Command unknown. Please? try another.");
                            break;
                    }
                };

                _tClient.StartReceiving();
            
                Console.ReadKey();
                
                await Task.Delay(0, stoppingToken);
            }
        }
    }
}
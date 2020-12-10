using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using TG_Types = Telegram.Bot.Types;

namespace Tg_test
{
    public class TgHostedService : BackgroundService
    {
        private static ITelegramBotClient _tClient { get; set; }

        private static readonly long adminUid = GIT_IGNORE.adminUid;
        private static readonly string token = GIT_IGNORE.token; // EDIT!!!!

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
                            var keyboard = new TG_Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                    new[]
                                    {
                                        new TG_Types.ReplyMarkups.KeyboardButton("What's now?"),
                                    },
                                    new[]
                                    {
                                        new TG_Types.ReplyMarkups.KeyboardButton("HELP!!!!"),
                                    },
                                },
                                ResizeKeyboard = true
                            };
                            _tClient.SendTextMessageAsync(uid, $"Hello world!\nMy commands:\n /today\n /start\n  /help\n /admin", replyMarkup: keyboard);
                            break;
                        case "/today":
                            _tClient.SendTextMessageAsync(uid, $"Now : {DateTime.Now:f}");
                            break;
                        case "/help":
                            _tClient.SendTextMessageAsync(uid, "Not implemented yet. :)");
                            break;
                        case "/admin":
                            _tClient.SendTextMessageAsync(uid, "Admin has recived your conseravtion!");
                            _tClient.SendTextMessageAsync(adminUid, $"@{userName} is calling help!");
                            break;
                        case "HELP!!!!":
                            _tClient.SendTextMessageAsync(uid, "Admin has recived your ask!");
                            _tClient.SendTextMessageAsync(adminUid, $"@{userName} is calling for help!");
                            break;
                        case "What's now?":
                            _tClient.SendTextMessageAsync(uid, $"Now : {DateTime.Now.ToString("f")}");
                            break;
                        default:
                            _tClient.SendTextMessageAsync(uid, $"Command unknown. Please? try another.");
                            break;
                    }
                };

                _tClient.StartReceiving();

                await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
            }
        }
    }
}
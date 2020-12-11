using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Telegram.Bot;
using TG_Types = Telegram.Bot.Types;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tg_test
{
    public class TgHostedService : BackgroundService
    {
        private static ITelegramBotClient _tClient { get; set; }

        private static readonly long adminUid = GIT_IGNORE.adminUid;
        private static readonly string token = GIT_IGNORE.token; 
        
        private static readonly string owmApiKey = "7a0d7228e2c6ede21fbd238bc158538e"; // MOVE TO GIT_IGNORE!!!
        private static readonly string owmIrpinUrl = $"http://api.openweathermap.org/data/2.5/weather?q=Irpin,%20UA&type=like&units=metric&appid={owmApiKey}";
        private static readonly string owmKyivUrl = $"http://api.openweathermap.org/data/2.5/weather?q=Kyiv,%20UA&type=like&units=metric&appid={owmApiKey}";
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
                        case "/weather":
                            var result = get(owmIrpinUrl);
                            try { 
                                var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                                _tClient.SendTextMessageAsync(uid, data["Weather"]);
                            } catch (Exception ex) { 
                            _tClient.SendTextMessageAsync(uid, $"Error: {ex.Message}");
                            }
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
        protected string get(string url)
        {
            try
            {
                string rt;

                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return rt;
            }

            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
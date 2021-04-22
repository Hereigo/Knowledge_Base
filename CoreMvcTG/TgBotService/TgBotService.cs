using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using TG_Types = Telegram.Bot.Types;

namespace CoreMvcTG.TgBot
{
    public class TgBotService : BackgroundService
    {
        private static ITelegramBotClient _tClient { get; set; }

        private readonly long adminUid = GIT_IGNORE.PASSWORDS.adminUid;
        private readonly string token = GIT_IGNORE.PASSWORDS.token;
        bool msgHandlerLocked = false;
        private readonly WeatherService weather = new WeatherService();
        private readonly CurrencyService currency = new CurrencyService();

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _tClient = new TelegramBotClient(token)
                {
                    Timeout = TimeSpan.FromSeconds(10)
                };

                var me = _tClient.GetMeAsync().Result;

                // bot answers anti-duplication:
                if (!msgHandlerLocked)
                {
                    msgHandlerLocked = true;
                    _tClient.OnMessage += HandleMessage;
                    msgHandlerLocked = false;
                }

                void HandleMessage(object sender, MessageEventArgs messageEventArgs)
                {
                    var text = messageEventArgs.Message.Text;
                    var uid = messageEventArgs.Message.Chat.Id;
                    var userName = messageEventArgs.Message.From.Username;

                    if (text is null)
                        return;

                    Console.WriteLine($"{uid} : {text}");

                    switch (text)
                    {
                        case STR.Commands:
                        case STR.CmdStart:
                            _tClient.SendTextMessageAsync(uid,
                                $"Hello world!\n My commands:\n " +
                                $"{STR.CmdToday}\n {STR.CmdStart}\n  {STR.CmdHelp}\n {STR.CmdAdmin}\n {STR.CmdWeather}",
                                replyMarkup: GetMainKeyboard());
                            break;
                        case STR.CmdHelp:
                            _tClient.SendTextMessageAsync(uid, "Not implemented yet. :)");
                            break;
                        case STR.CmdAdmin:
                            _tClient.SendTextMessageAsync(uid, "Admin has received your conseravtion!");
                            _tClient.SendTextMessageAsync(adminUid, $"@{userName} is calling help!");
                            break;
                        case STR.AskHelp:
                            _tClient.SendTextMessageAsync(uid, "Admin has received your ask!");
                            _tClient.SendTextMessageAsync(adminUid, $"@{userName} is calling for help!");
                            break;
                        case STR.WhatsNow:
                        case STR.CmdToday:
                            _tClient.SendTextMessageAsync(uid, $"Now : {DateTime.Now:f}");
                            break;
                        case STR.Currency:
                        case STR.CmdCurrency:
                            try
                            {
                                string currencyInfo = currency.Get();
                                _tClient.SendTextMessageAsync(uid, currencyInfo);
                            }
                            catch (Exception ex)
                            {
                                _tClient.SendTextMessageAsync(uid, $"Error: {ex.Message}");
                            }

                            break;
                        case STR.Weather:
                        case STR.CmdWeather:
                            try
                            {
                                string irpinInfo = weather.Get("Irpin");
                                string kyivInfo = weather.Get("Kyiv");
                                _tClient.SendTextMessageAsync(uid, $"Kyiv:\n{kyivInfo}\n\nIrpin:\n{irpinInfo}");
                            }
                            catch (Exception ex)
                            {
                                _tClient.SendTextMessageAsync(uid, $"Error: {ex.Message}");
                            }

                            break;
                        default:
                            _tClient.SendTextMessageAsync(uid, $"Command unknown. Please? try another.");
                            break;
                    }
                }

                _tClient.StartReceiving();

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }

        private static ReplyKeyboardMarkup GetMainKeyboard()
        {
            return new TG_Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new TG_Types.ReplyMarkups.KeyboardButton(STR.WhatsNow),
                        new TG_Types.ReplyMarkups.KeyboardButton(STR.AskHelp),
                    },
                    new[]
                    {
                        new TG_Types.ReplyMarkups.KeyboardButton(STR.Commands),
                        new TG_Types.ReplyMarkups.KeyboardButton(STR.Weather),
                        new TG_Types.ReplyMarkups.KeyboardButton(STR.Currency),
                    },
                },
                ResizeKeyboard = true
            };
        }
    }
}
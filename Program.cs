using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUpdateHandler, Updatehandler>();
builder.Services.AddHostedService<BotHostBackgroundService>();
builder.Services.AddSingleton<ITelegramBotClient>(
    new TelegramBotClient(builder.Configuration.GetValue("BoTApiKey",string.Empty)));
builder.Build().Run();

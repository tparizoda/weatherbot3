using Telegram.Bot;
using Telegram.Bot.Polling;

public class BotHostBackgroundService : BackgroundService
{
    private readonly ILogger<BotHostBackgroundService> logger;
    private readonly ITelegramBotClient telegramBotClient;
    private readonly IUpdateHandler updateHandler;

    public BotHostBackgroundService(
        ILogger<BotHostBackgroundService> logger,
        ITelegramBotClient telegramBotClient,
        IUpdateHandler updateHandler)
    {
        this.logger = logger;
        this.telegramBotClient = telegramBotClient;
        this.updateHandler = updateHandler;
    }
        
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var me = await telegramBotClient.GetMeAsync(stoppingToken);
        logger.LogInformation("Bot started: {usernmae}", me.Username);

        telegramBotClient.StartReceiving(
            updateHandler : updateHandler,
            receiverOptions : default,
            cancellationToken : stoppingToken
        );
    }
}
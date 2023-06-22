using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

public partial class Updatehandler : IUpdateHandler
{
    private readonly ILogger<Updatehandler> logger;

    public Updatehandler(ILogger<Updatehandler> logger)
    {
        this.logger = logger;
    }
    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Error with bot pooling");
        return Task.CompletedTask;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var handletask = update.Type switch
        {
            UpdateType.Message => HandleMessageUpdateAsync(botClient, update.Message, cancellationToken),
            UpdateType.EditedMessage => HandleEditedMessageUpdateAsync(botClient, update.EditedMessage, cancellationToken),
            _ => HandleUnknownUpdateAsync(botClient, update, cancellationToken)
        };

        try
        {
            await handletask;
        }
        catch(Exception ex)
        {
            await HandlePollingErrorAsync(botClient, ex, cancellationToken);
        }

    }

    private Task HandleUnknownUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        logger.LogInformation("Recieved {updateType} message",update.Type);
        return Task.CompletedTask;
    }
}
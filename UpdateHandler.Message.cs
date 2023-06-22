using Telegram.Bot;
using Telegram.Bot.Types;

public partial class Updatehandler
{
    private Task HandleMessageUpdateAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        var username = message.From?.Username 
            ?? message.From.FirstName;
        logger.LogInformation("Recieved message from {username}",username);
        return Task.CompletedTask;
    }
}
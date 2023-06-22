using Telegram.Bot;
using Telegram.Bot.Types;

public partial class Updatehandler
{
    private Task HandleEditedMessageUpdateAsync(ITelegramBotClient botClient, Message editedmessage, CancellationToken cancellationToken)
    {
        var username = editedmessage.From?.Username 
            ?? editedmessage.From.FirstName;
        logger.LogInformation("Recieved eddited message from {username}",username);

        return Task.CompletedTask;
    }
}
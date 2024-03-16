using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;

public class MessageRepository(ApplicationDbContext dbContext) : IMessageRepository
{
    public async Task CreateMessage(Message message, CancellationToken cancellationToken)
    {
        var messageModel = MapToModel(message);
        await dbContext.AddAsync(messageModel, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateMessage(Message message, CancellationToken cancellationToken)
    {
        var existingMessage = await dbContext.Messages
            .Include(m => m.Chat)
            .Include(m => m.Sender)
            .FirstOrDefaultAsync(m => m.Id == message.Id, cancellationToken);

        if (existingMessage != null)
        {
            existingMessage.MessageText = message.MessageText;
            existingMessage.SentTime = message.SentTime;

            if (existingMessage.Chat != message.Chat)
                existingMessage.Chat = message.Chat;

            if (existingMessage.Sender != message.Sender)
                existingMessage.Sender = message.Sender;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
        else
        {
            throw new ArgumentException("Message not found", nameof(message));
        }
    }

    public async Task DeleteMessage(Message message, CancellationToken cancellationToken)
    {
        var existingMessageModel = await dbContext.Messages.FindAsync(message.Id);
        
        if (existingMessageModel != null)
        {
            dbContext.Messages.Remove(existingMessageModel);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    private Message MapToEntity(MessageModel messageModel)
    {
        return MessageMapper.ToEntity(messageModel);
    }

    private MessageModel MapToModel(Message entity)
    {
        return MessageMapper.ToModel(entity);
    }
}
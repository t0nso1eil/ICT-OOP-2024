using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;

public class ChatRepository(ApplicationDbContext dbContext) : IChatRepository
{
    public async Task CreateChat(Chat chat, CancellationToken cancellationToken)
    {
        var chatModel = MapToModel(chat);
        await dbContext.AddAsync(chatModel, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Message>> GetChatMessages(Chat chat, CancellationToken cancellationToken)
    {
        var chatModel = await dbContext.Chats
            .Include(c => c.Messages)
            .FirstOrDefaultAsync(c => c.Id == chat.Id, cancellationToken);

        if (chatModel != null)
        {
            return chatModel.Messages.Select(m => MapToEntity(m));
        }

        return Enumerable.Empty<Message>();
    }

    private Chat MapToEntity(ChatModel chatModel)
    {
        return ChatMapper.ToEntity(chatModel);
    }

    private ChatModel MapToModel(Chat entity)
    {
        return ChatMapper.ToModel(entity);
    }
}
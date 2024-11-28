using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Persistence.Repositories
{
    public class ChatRepository(AcilKanContext _context) : IChatService
    {
        public async Task<List<Chat>> GetChatsByUserOrderedByDateAsync(int userId, int toUserId)
        {
            return await _context.Chats
                .Where(
                    x =>
                    (x.UserId == userId && x.ToUserId == toUserId) 
                    ||
                    (x.UserId == toUserId && x.ToUserId == userId)
                )
                .OrderBy(x => x.SendDate)
                .ToListAsync();
        }
    }
}

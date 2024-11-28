using AcilKan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Interfaces
{
    public interface IChatService
    {
        Task<List<Chat>> GetChatsByUserOrderedByDateAsync(int userId, int toUserId);
    }
}

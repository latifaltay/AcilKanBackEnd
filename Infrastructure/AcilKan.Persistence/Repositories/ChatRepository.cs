using AcilKan.Application.Features.Mediator.Results.ChatResults;
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
                    (x.FromUserId == userId && x.ToUserId == toUserId)
                    ||
                    (x.FromUserId == toUserId && x.ToUserId == userId)
                )
                .Include(x => x.ToUser)
                .OrderBy(x => x.SendDate)
                .ToListAsync();
        }


        //public async Task<List<Chat>> GetChatsPreviewAsync(int userId)
        //{
        //    var previews = await _context.Chats
        //        .Where(chat => chat.FromUserId == userId || chat.ToUserId == userId) // Kullanıcıyla ilişkili konuşmalar
        //        .Include(chat => chat.ToUser) // Karşı kullanıcıyı dahil et
        //        .Include(chat => chat.FromUser) // Gönderen kullanıcıyı dahil et
        //        .GroupBy(chat => chat.FromUserId == userId ? chat.ToUserId : chat.FromUserId) // Karşı kullanıcıya göre gruplama
        //        .Select(group => new Chat
        //        {
        //            FromUserId = group.FirstOrDefault().FromUserId,
        //            ToUserId = group.FirstOrDefault().ToUserId,
        //            Message = group.OrderByDescending(chat => chat.SendDate) // Son mesaj
        //                .FirstOrDefault().Message.Substring(0, 20), // Son mesajın ilk 20 karakteri
        //            SendDate = group.Max(chat => chat.SendDate), // En son mesajın tarihi
        //            ToUser = group.FirstOrDefault().ToUser // Karşı kullanıcı bilgisi
        //        })
        //        .ToListAsync();

        //    return previews;
        //}


        // Çalışıyor
        //public async Task<List<Chat>> GetChatsPreviewAsync(int userId)
        //{
        //    var previews = await _context.Chats
        //        .Where(chat => chat.FromUserId == userId || chat.ToUserId == userId) // Kullanıcıyla ilişkili konuşmalar
        //        .Include(chat => chat.ToUser) // Karşı kullanıcıyı dahil et
        //        .Include(chat => chat.FromUser) // Gönderen kullanıcıyı dahil et
        //        .GroupBy(chat => chat.FromUserId == userId ? chat.ToUserId : chat.FromUserId) // Karşı kullanıcıya göre gruplama
        //        .Select(group => new Chat
        //        {
        //            FromUserId = group.FirstOrDefault().FromUserId,
        //            ToUserId = group.FirstOrDefault().ToUserId,
        //            Message = group.OrderByDescending(chat => chat.SendDate) // Son mesajı al
        //                .FirstOrDefault().Message.Substring(0, 20), // Son mesajın ilk 20 karakterini al
        //            SendDate = group.Max(chat => chat.SendDate), // En son mesajın tarihi
        //            ToUser = group.FirstOrDefault().ToUser // Karşı kullanıcı bilgisi
        //        })
        //        .ToListAsync();

        //    return previews;
        //}


        //public async Task<List<Chat>> GetChatsPreviewAsync(int userId)
        //{
        //    var previews = await _context.Chats
        //        .Where(chat => chat.FromUserId == userId || chat.ToUserId == userId) // Kullanıcıyla ilişkili konuşmalar
        //        .Include(chat => chat.ToUser) // Karşı kullanıcıyı dahil et
        //        .Include(chat => chat.FromUser) // Gönderen kullanıcıyı dahil et
        //        .GroupBy(chat => chat.FromUserId == userId ? chat.ToUserId : chat.FromUserId) // Karşı kullanıcıya göre gruplama
        //        .Select(group => new Chat
        //        {
        //            FromUserId = group.FirstOrDefault().FromUserId,
        //            ToUserId = group.FirstOrDefault().ToUserId,
        //            Message = group.OrderByDescending(chat => chat.SendDate) // Son mesajı al
        //                .FirstOrDefault().Message.Length > 20 ?
        //                group.OrderByDescending(chat => chat.SendDate).FirstOrDefault().Message.Substring(0, 20) :
        //                group.OrderByDescending(chat => chat.SendDate).FirstOrDefault().Message, // Son mesajın ilk 20 karakterini al
        //            SendDate = group.Max(chat => chat.SendDate), // En son mesajın tarihi
        //            ToUser = group.FirstOrDefault().ToUser // Karşı kullanıcı bilgisi
        //        })
        //        .ToListAsync();

        //    return previews;
        //}

        public async Task<List<Chat>> GetChatsPreviewAsync(int userId)
        {
            var previews = await _context.Chats
                .Where(chat => chat.FromUserId == userId || chat.ToUserId == userId) // Kullanıcıyla ilişkili konuşmalar
                .Include(chat => chat.ToUser) // Karşı kullanıcıyı dahil et
                .Include(chat => chat.FromUser) // Gönderen kullanıcıyı dahil et
                .GroupBy(chat => chat.FromUserId == userId ? chat.ToUserId : chat.FromUserId) // Karşı kullanıcıya göre gruplama
                .Select(group => new Chat
                {
                    FromUserId = group.FirstOrDefault().FromUserId,
                    ToUserId = group.FirstOrDefault().ToUserId,
                    Message = group.OrderByDescending(chat => chat.SendDate) // Son mesajı al
                        .FirstOrDefault().Message.Length > 20 ?
                        group.OrderByDescending(chat => chat.SendDate).FirstOrDefault().Message.Substring(0, 20) :
                        group.OrderByDescending(chat => chat.SendDate).FirstOrDefault().Message, // Son mesajın ilk 20 karakterini al
                    SendDate = group.Max(chat => chat.SendDate), // En son mesajın tarihi
                    ToUser = userId == group.FirstOrDefault().FromUserId ? group.FirstOrDefault().ToUser : group.FirstOrDefault().FromUser // Karşı kullanıcı bilgisi
                })
                .ToListAsync();

            return previews;
        }




        //public async Task<List<GetContactsQueryResult>> GetChatsPreviewAsync(int userId)
        //{
        //    var previews = await _context.Chats
        //        .Where(chat => chat.FromUserId == userId || chat.ToUserId == userId) // Kullanıcıyla ilişkili konuşmalar
        //        .Include(chat => chat.ToUser) // Karşı kullanıcıyı dahil et
        //        .Include(chat => chat.FromUser) // Gönderen kullanıcıyı dahil et
        //        .GroupBy(chat => chat.FromUserId == userId ? chat.ToUserId : chat.FromUserId) // Karşı kullanıcıya göre gruplama
        //        .Select(group => new GetContactsQueryResult
        //        {
        //            UserFullName = group.FirstOrDefault().ToUser.Name, // Karşıdaki kullanıcının adı soyadı
        //            SendDate = group.Max(chat => chat.SendDate), // En son mesajın tarihi
        //            LastMessageInfo = group.OrderByDescending(chat => chat.SendDate) // Son mesajı al
        //                .FirstOrDefault().Message.Substring(0, 20) // Son mesajın ilk 20 karakteri
        //        })
        //        .ToListAsync();

        //    return previews;
        //}

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Interfaces
{
    public interface IChatClient
    {
        // Sunucudan gelen mesajı almak için metod
        Task ReceiveMessage(string senderUserId, string message);

        // Kullanıcı bağlantısı gerçekleştiğinde tüm kullanıcılara bildirilen metod
        Task UserConnected(string userId);

        // Kullanıcı bağlantısı koptuğunda tüm kullanıcılara bildirilen metod
        Task UserDisconnected(string userId);
    }
}

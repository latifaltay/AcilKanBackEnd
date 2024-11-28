using AcilKan.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace AcilKan.WebAPI.Hubs
{
    // SignalR Hub sınıfı, IChatClient üzerinden tip güvenliğini sağlar
    public class ChatHub : Hub<IChatClient>
    {
        // Statik kullanıcı listesi, kullanıcı bağlantılarını tutmak için
        public static Dictionary<string, string> Users = new();

        // Mesaj gönderme metodu
        public async Task SendMessage(string senderUserId, string receiverUserId, string message)
        {
            // Alıcıya mesaj gönder
            await Clients.User(receiverUserId).ReceiveMessage(senderUserId, message);
        }

        // Kullanıcı bağlandığında, bağlantı kimliğiyle birlikte kullanıcıyı ekleme
        public async Task ConnectUser(string userId)
        {
            // Bağlantı kimliği ile kullanıcı ID'si arasındaki ilişkiyi tutmak için Users dictionary'si kullanılabilir
            Users[Context.ConnectionId] = userId;

            // Kullanıcı bağlandığında tüm client'lara bildirim gönder
            await Clients.All.UserConnected(userId);
        }

        // Kullanıcı bağlantısı koptuğunda, tüm kullanıcılara bildirim gönder
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Bağlantısı kopan kullanıcıyı bul
            var userId = Users.ContainsKey(Context.ConnectionId) ? Users[Context.ConnectionId] : "Bağlantı Koptu";
            Users.Remove(Context.ConnectionId);

            // Kullanıcı bağlantısının kesildiğini bildirme
            await Clients.All.UserDisconnected(userId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
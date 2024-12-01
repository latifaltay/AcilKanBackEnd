using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime SendDate { get; set; }
        public AppUser ToUser { get; set; }
        public AppUser FromUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.AppUserResults
{
    public class GetAppUserByIdQueryResult
    {
        public int Id { get; set; }         // IdentityUser'dan gelen Id
        public string UserName { get; set; } // IdentityUser'dan gelen kullanıcı adı
        public string Email { get; set; }    // IdentityUser'dan gelen e-posta
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string BloodGroup { get; set; }
        public bool Gender { get; set; }
    }
}

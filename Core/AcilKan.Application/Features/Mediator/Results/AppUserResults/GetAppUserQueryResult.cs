using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.AppUserResults
{
    public class GetAppUserQueryResult
    {
        public int Id { get; set; }         // IdentityUser'dan gelen Id
        public string UserName { get; set; } // IdentityUser'dan gelen kullanıcı adı
        public string Email { get; set; }    // IdentityUser'dan gelen e-posta
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Surname { get; set; }
        public string BloodGroup { get; set; }
        public string ImageUrl { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool Gender { get; set; }
    }
}

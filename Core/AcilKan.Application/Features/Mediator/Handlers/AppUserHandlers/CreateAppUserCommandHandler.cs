using AcilKan.Application.Features.Mediator.Commands.AppUserCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler(UserManager<AppUser> _userManager, ITCIdentityVerificationService _tcVerificationService)
        : IRequestHandler<CreateAppUserCommand>
    {
        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            // ✅ TC Kimlik doğrulaması yap (MERNIS API çağrısı)
            bool isValidTC = await _tcVerificationService.ValidateTCIdentity(
                request.TC, request.Name, request.Surname, request.BirthDate.Year
            );

            if (!isValidTC)
            {
                throw new Exception("❌ Geçersiz TC Kimlik Numarası! Lütfen doğru bilgileri giriniz.");
            }

            // ✅ Kullanıcı nesnesini oluştur
            AppUser appUser = new()
            {
                UserName = request.Email,
                TC = request.TC,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                BloodGroup = request.BloodGroup,
                Gender = request.Gender,
                CityId = request.CityId,
                DistrictId = request.DistrictId,
                RegisterDate = DateTime.UtcNow, // UTC tarih kullan
                BirthDate = request.BirthDate,
            };

            // ✅ Kullanıcıyı oluştur
            var result = await _userManager.CreateAsync(appUser, request.Password);

            // ✅ Kullanıcı oluşturulamazsa hata fırlat
            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"❌ Kullanıcı oluşturulamadı: {errors}");
            }
        }
    }
}

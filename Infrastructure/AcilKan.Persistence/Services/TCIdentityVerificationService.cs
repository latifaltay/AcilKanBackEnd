using AcilKan.Application.Interfaces;

namespace AcilKan.Persistence.Services
{
    public class TCIdentityVerificationService : ITCIdentityVerificationService
    {
        public async Task<bool> ValidateTCIdentity(string tcNo, string name, string surname, int birthYear)
        {
            try
            {
                using (var client = new TCIdentityVerification.KPSPublicSoapClient(TCIdentityVerification.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap))
                {
                    var result = await client.TCKimlikNoDogrulaAsync(
                        Convert.ToInt64(tcNo),
                        name.ToUpper(),
                        surname.ToUpper(),
                        birthYear
                    );

                    return result.Body.TCKimlikNoDogrulaResult;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ TC Kimlik Doğrulama Hatası: " + ex.Message);
                return false;
            }
        }
    }
}

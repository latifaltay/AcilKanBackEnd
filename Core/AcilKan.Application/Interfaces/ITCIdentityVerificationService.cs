namespace AcilKan.Application.Interfaces
{
    public interface ITCIdentityVerificationService
    {
        Task<bool> ValidateTCIdentity(string tcNo, string name, string surname, int birthYear);
    }
}

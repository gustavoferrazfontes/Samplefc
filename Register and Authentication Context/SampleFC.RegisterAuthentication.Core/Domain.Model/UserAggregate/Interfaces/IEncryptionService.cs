namespace SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Interfaces
{
    public interface IEncryptionService
    {
        string GenereteEncryption(string password);
    }
}

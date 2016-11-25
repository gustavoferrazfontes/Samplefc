namespace SampleFC.RegisterAuthentication.Core.ApplicationLayer.Interfaces
{
    public interface IUserAuthentication
    {
        void Authenticate(string userName, string password);
    }
}

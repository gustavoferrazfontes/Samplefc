namespace SampleFC.RegisterAuthentication.Core.ApplicationLayer.Commands
{
    public class RegisterCommand
    {
        public string Email { get;  set; }
        public string EmailConfirmed { get;  set; }

        public string Password { get;  set; }
        public string UserName { get;  set; }

    }
}

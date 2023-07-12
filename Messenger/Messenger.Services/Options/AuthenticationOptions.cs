using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Messenger.Services.Options
{
    public static class AuthenticationOptions
    {
        public const string ISSUER = "Messenger";

        public const string AUDIENCE = "MessengerUser";

        const string KEY = "XUhUQs0fz75LJh0g8tNy";

        public const int LIFETIME = 60;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}

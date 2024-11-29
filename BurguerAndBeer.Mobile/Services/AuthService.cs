using BurguerAndBeer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.Services
{
    public class AuthService
    {
        private const string AUTH_KEY = "AuthKey";
        public LoggedInUser? User { get; private set; }
        public string? Token { get; private set; }

        public void Signin(AuthResponseDto dto)
        {
            var serialized = JsonSerializer.Serialize(dto);

            Preferences.Default.Set(AUTH_KEY, serialized);

            (User, Token) = dto;
        }

        public void Signout()
        {
            Preferences.Default.Remove(AUTH_KEY);

            (User, Token) = (null, null);
        }

        public void Initialize()
        {
            if (Preferences.Default.ContainsKey(AUTH_KEY))
            {
                var serialized = Preferences.Default.Get<string?>(AUTH_KEY, null);

                if (string.IsNullOrEmpty(serialized))
                {
                    Preferences.Default.Remove(AUTH_KEY);
                }
                else
                {
                    (User, Token) = JsonSerializer.Deserialize<AuthResponseDto>(serialized)!;
                }
            }
        }
    }
}

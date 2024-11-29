using System.Collections.Generic;
using System.Text;

namespace BurguerAndBeer.Shared.Dtos
{
    public record SignupRequestDto(string Name, string Email, string Password, string Address);
}

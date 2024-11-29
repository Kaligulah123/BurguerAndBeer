using System;

namespace BurguerAndBeer.Shared.Dtos
{
    public record LoggedInUser(Guid Id, string Name, string Email, string Address);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Shared.Dtos
{
    public record ChangePasswordDto(string OldPassword, string NewPassword);
    
}

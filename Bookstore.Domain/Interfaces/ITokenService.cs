using Bookstore.Domain.DTOs.Auth;
using Bookstore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Interfaces
{
    public interface ITokenService
    {
        TokenResultDto CreateJwtToken(User user, IList<string> roles);
    }
}

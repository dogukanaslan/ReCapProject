using Core.Entities.Concrete;
using Core1.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core1.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}

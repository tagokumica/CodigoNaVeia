using System;
using Microsoft.AspNetCore.Identity;

namespace Infra.CrossCutting.Security.Model
{
    public class UserToken: IdentityUserToken<Guid>
    {
        
    }
}
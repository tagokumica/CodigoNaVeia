using System;
using Microsoft.AspNetCore.Identity;

namespace Infra.CrossCutting.Security.Model
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }
        public string Name { get; set; }


    }
}
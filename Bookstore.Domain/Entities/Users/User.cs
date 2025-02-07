﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Entities.Users
{
    public class User : IdentityUser<Guid>
    {
        public Guid? ClientId { get; set; }  
        public virtual Client? Client { get; set; }
    }
}

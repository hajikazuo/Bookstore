﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.DTOs.Auth
{
    public class TokenResultDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

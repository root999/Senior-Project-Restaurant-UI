using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class AuthtokenToken
    {
        public string Key { get; set; }
        public byte[] Created { get; set; }
        public long UserId { get; set; }

        public virtual MyapiCustomer User { get; set; }
    }
}

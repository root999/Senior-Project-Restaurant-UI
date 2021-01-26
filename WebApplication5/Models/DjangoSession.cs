using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class DjangoSession
    {
        public string SessionKey { get; set; }
        public string SessionData { get; set; }
        public byte[] ExpireDate { get; set; }
    }
}

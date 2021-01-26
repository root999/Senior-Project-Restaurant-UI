using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class AccountEmailaddress
    {
        public AccountEmailaddress()
        {
            AccountEmailconfirmations = new HashSet<AccountEmailconfirmation>();
        }

        public long Id { get; set; }
        public byte[] Verified { get; set; }
        public byte[] Primary { get; set; }
        public long UserId { get; set; }
        public string Email { get; set; }

        public virtual MyapiCustomer User { get; set; }
        public virtual ICollection<AccountEmailconfirmation> AccountEmailconfirmations { get; set; }
    }
}

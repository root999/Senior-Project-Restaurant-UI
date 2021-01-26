using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class AccountEmailconfirmation
    {
        public long Id { get; set; }
        public byte[] Created { get; set; }
        public byte[] Sent { get; set; }
        public string Key { get; set; }
        public long EmailAddressId { get; set; }

        public virtual AccountEmailaddress EmailAddress { get; set; }
    }
}

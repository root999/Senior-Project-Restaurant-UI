using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class MyapiCustomerGroup
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long GroupId { get; set; }

        public virtual MyapiCustomer Customer { get; set; }
        public virtual AuthGroup Group { get; set; }
    }
}

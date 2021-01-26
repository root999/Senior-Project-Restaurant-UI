using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class MyapiCustomerUserPermission
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long PermissionId { get; set; }

        public virtual MyapiCustomer Customer { get; set; }
        public virtual AuthPermission Permission { get; set; }
    }
}

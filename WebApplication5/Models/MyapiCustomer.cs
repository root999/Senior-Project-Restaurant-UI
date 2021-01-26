using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class MyapiCustomer
    {
        public MyapiCustomer()
        {
            AccountEmailaddresses = new HashSet<AccountEmailaddress>();
            MyapiCustomerGroups = new HashSet<MyapiCustomerGroup>();
            MyapiCustomerUserPermissions = new HashSet<MyapiCustomerUserPermission>();
            MyapiOrders = new HashSet<MyapiOrder>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] DateJoined { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public byte[] IsActive { get; set; }
        public byte[] IsStaff { get; set; }
        public byte[] IsSuperuser { get; set; }
        public byte[] LastLogin { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }

        public virtual AuthtokenToken AuthtokenToken { get; set; }
        public virtual ICollection<AccountEmailaddress> AccountEmailaddresses { get; set; }
        public virtual ICollection<MyapiCustomerGroup> MyapiCustomerGroups { get; set; }
        public virtual ICollection<MyapiCustomerUserPermission> MyapiCustomerUserPermissions { get; set; }
        public virtual ICollection<MyapiOrder> MyapiOrders { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class AuthGroup
    {
        public AuthGroup()
        {
            AuthGroupPermissions = new HashSet<AuthGroupPermission>();
            AuthUserGroups = new HashSet<AuthUserGroup>();
            MyapiCustomerGroups = new HashSet<MyapiCustomerGroup>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; set; }
        public virtual ICollection<AuthUserGroup> AuthUserGroups { get; set; }
        public virtual ICollection<MyapiCustomerGroup> MyapiCustomerGroups { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class AuthPermission
    {
        public AuthPermission()
        {
            AuthGroupPermissions = new HashSet<AuthGroupPermission>();
            AuthUserUserPermissions = new HashSet<AuthUserUserPermission>();
            MyapiCustomerUserPermissions = new HashSet<MyapiCustomerUserPermission>();
        }

        public long Id { get; set; }
        public long ContentTypeId { get; set; }
        public string Codename { get; set; }
        public string Name { get; set; }

        public virtual DjangoContentType ContentType { get; set; }
        public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; set; }
        public virtual ICollection<AuthUserUserPermission> AuthUserUserPermissions { get; set; }
        public virtual ICollection<MyapiCustomerUserPermission> MyapiCustomerUserPermissions { get; set; }
    }
}

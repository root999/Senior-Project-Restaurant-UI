using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class AuthGroupPermission
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public long PermissionId { get; set; }

        public virtual AuthGroup Group { get; set; }
        public virtual AuthPermission Permission { get; set; }
    }
}

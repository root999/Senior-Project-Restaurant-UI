using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class DjangoContentType
    {
        public DjangoContentType()
        {
            AuthPermissions = new HashSet<AuthPermission>();
            DjangoAdminLogs = new HashSet<DjangoAdminLog>();
        }

        public long Id { get; set; }
        public string AppLabel { get; set; }
        public string Model { get; set; }

        public virtual ICollection<AuthPermission> AuthPermissions { get; set; }
        public virtual ICollection<DjangoAdminLog> DjangoAdminLogs { get; set; }
    }
}

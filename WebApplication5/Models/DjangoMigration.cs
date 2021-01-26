using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class DjangoMigration
    {
        public long Id { get; set; }
        public string App { get; set; }
        public string Name { get; set; }
        public byte[] Applied { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class MyapiMenuProduct
    {
        public long Id { get; set; }
        public long MenuId { get; set; }
        public long ProductId { get; set; }

        public virtual MyapiMenu Menu { get; set; }
        public virtual MyapiProduct Product { get; set; }
    }
}

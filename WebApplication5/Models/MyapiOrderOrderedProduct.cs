using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class MyapiOrderOrderedProduct
    {
        public long Id { get; set; }
        public long ProductCount { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }

        public virtual MyapiOrder Order { get; set; }
        public virtual MyapiProduct Product { get; set; }
    }
}

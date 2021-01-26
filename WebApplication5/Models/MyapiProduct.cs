using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class MyapiProduct
    {
        public MyapiProduct()
        {
            MyapiMenuProducts = new HashSet<MyapiMenuProduct>();
            MyapiOrderOrderedProducts = new HashSet<MyapiOrderOrderedProduct>();
            MyapiProductsinorders = new HashSet<MyapiProductsinorder>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PhotoUrl { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }

        public virtual ICollection<MyapiMenuProduct> MyapiMenuProducts { get; set; }
        public virtual ICollection<MyapiOrderOrderedProduct> MyapiOrderOrderedProducts { get; set; }
        public virtual ICollection<MyapiProductsinorder> MyapiProductsinorders { get; set; }
    }
}

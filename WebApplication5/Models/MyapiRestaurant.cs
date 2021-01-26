using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class MyapiRestaurant
    {
        public MyapiRestaurant()
        {
            MyapiOrders = new HashSet<MyapiOrder>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LogoUrl { get; set; }

        public virtual MyapiMenu MyapiMenu { get; set; }
        public virtual ICollection<MyapiOrder> MyapiOrders { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class MyapiMenu
    {
        public MyapiMenu()
        {
            MyapiMenuProducts = new HashSet<MyapiMenuProduct>();
        }

        public long RestaurantId { get; set; }

        public virtual MyapiRestaurant Restaurant { get; set; }
        public virtual ICollection<MyapiMenuProduct> MyapiMenuProducts { get; set; }
    }
}

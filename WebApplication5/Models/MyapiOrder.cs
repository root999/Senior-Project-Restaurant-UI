using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication5.Models
{
    public partial class MyapiOrder
    {
        public MyapiOrder()
        {
            MyapiOrderOrderedProducts = new HashSet<MyapiOrderOrderedProduct>();
            MyapiProductsinorders = new HashSet<MyapiProductsinorder>();
        }

        public long Id { get; set; }
        public byte[] IssueTime { get; set; }
        public long CustomerId { get; set; }
        public long RestaurantId { get; set; }
        public byte[] IssueDate { get; set; }
        public byte[] PlannedTime { get; set; }
        public byte[] PlannedDate { get; set; }

        public virtual MyapiCustomer Customer { get; set; }
        public virtual MyapiRestaurant Restaurant { get; set; }
        public virtual ICollection<MyapiOrderOrderedProduct> MyapiOrderOrderedProducts { get; set; }
        public virtual ICollection<MyapiProductsinorder> MyapiProductsinorders { get; set; }
    }
}

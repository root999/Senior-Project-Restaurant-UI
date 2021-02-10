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
        public DateTime IssueTime { get; set; }
        public long CustomerId { get; set; }
        public long RestaurantId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PlannedTime { get; set; }
        public DateTime PlannedDate { get; set; }
        public String Status { get; set; }
        public virtual MyapiCustomer Customer { get; set; }
        public virtual MyapiRestaurant Restaurant { get; set; }
        public virtual ICollection<MyapiOrderOrderedProduct> MyapiOrderOrderedProducts { get; set; }
        public virtual ICollection<MyapiProductsinorder> MyapiProductsinorders { get; set; }
    }
}

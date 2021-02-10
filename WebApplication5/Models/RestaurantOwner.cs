using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class RestaurantOwner
    {
        public string email  { get;set; }
        public string password { get; set; }
        public long RestaurantId { get; set; }

        public virtual MyapiRestaurant Restaurant { get; set; }
    }
}

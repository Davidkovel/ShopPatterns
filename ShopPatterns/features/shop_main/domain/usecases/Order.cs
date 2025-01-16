using ShopPatterns.core.enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPatterns.features.shop_main.domain.usecases.Order
{
    public class OrderProduct
    {
        public string Name { get; set; }
        public string DeliveryAdress { get; set; }
        public List<Product> CartList { get; set; }

        public OrderProduct()
        {
            CartList = new List<Product>();
        }


    }
}

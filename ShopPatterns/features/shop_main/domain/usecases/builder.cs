using ShopPatterns.core.enteties;
using ShopPatterns.features.cart.data.datasources;
using ShopPatterns.features.shop_main.domain.usecases.Order;

namespace ShopPatterns.features.shop_main.domain.usecases.Builder
{
    public interface IBuilder
    {
        void SetName();
        void SetDeliveryAdress();
        void setProducts();
    }

    public abstract class Builder : IBuilder
    {
        protected OrderProduct productOrder { get; set; }
        public abstract void SetName();
        public abstract void SetDeliveryAdress();
        public abstract void setProducts();
    }

    public class OrderBuilder : Builder
    {
        private CartManager _CartManager { get; set; }
        public OrderBuilder (CartManager cartManager)
        {
            productOrder = new OrderProduct();
            _CartManager = cartManager;
        }
        public override void SetName()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            productOrder.Name = name;
        }

        public override void SetDeliveryAdress()
        {
            Console.WriteLine("Enter your adress for delivering");
            string adress = Console.ReadLine();
            productOrder.DeliveryAdress = adress;
        }

        public override void setProducts()
        {
            productOrder.CartList = _CartManager.Cart;
            Console.WriteLine("The order is success. Wait for your order during 2 weeks");
            _CartManager.ClearCart();
        }
    }


}
